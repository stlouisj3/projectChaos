using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManager : MonoBehaviour
{
    private bool play;

    public delegate bool playstate();
    public static playstate currState;

    [SerializeField]
    private GameObject deathScreen;

    public delegate void gameState();
    public static gameState resumeGame;
    public static gameState pauseGame;
    public static gameState dead;

    audioManager audio;

    IEnumerator Start()
    {
        audio = audioManager.Instance;
        play = true;
        deathScreen.SetActive(false);
        yield return new WaitForEndOfFrame();
        currState = getPlay;
        resumeGame = resume;
        pauseGame = pause;
        dead = death;
        resume();

        
    }

   
    private bool getPlay()
    {
        return play;
    }

    private void pause()
    {
        play = false;
        audio.pauseMusic();
        roundManager.stopSpawn();
        animationController.stopTime(true);
        navMeshFix.changeNav(false);
        
        
    }

    private void resume()
    {
        play = true;
        PlayerMovement.moveStart();
        shootingScript.startShoot();
        CameraControl.camMove();       
        StartCoroutine(audio.resumeShuffle());
        roundManager.continueSpawn();
        abilityManager.getInput();
        animationController.stopTime(false);
        navMeshFix.changeNav(true);
        
    }

    private void death()
    {
        play = false;
        pause();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        deathScreen.SetActive(true);
    }

    IEnumerator resumeFix()
    {
        yield return new WaitForEndOfFrame();
        play = true;
        PlayerMovement.moveStart();
        shootingScript.startShoot();        
        CameraControl.camMove();
        animationController.stopTime(false);
        navMeshFix.changeNav(true);
    }

   
}
