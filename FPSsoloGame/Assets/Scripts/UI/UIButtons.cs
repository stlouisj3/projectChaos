using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIButtons : MonoBehaviour
{
   /* [SerializeField]
    private TextMeshProUGUI xSens;

    [SerializeField]
    private TextMeshProUGUI ySens;*/

    [SerializeField]
    private GameObject loadingScreen;

    [SerializeField]
    private Slider musicSlide;
    [SerializeField]
    private Slider sfxSlide;
    [SerializeField]
    private Slider xSensSlide;
    [SerializeField]
    private Slider ySensSlide;

    [SerializeField]
    private AudioMixer mixer;


    public classScriptObj gameClass;
    public classScriptObj classObj;
    public PlayerSaveData player;

    private void Awake()
    {
        mixer.SetFloat("SFXVol", player.sfxVol);
        mixer.SetFloat("MusicVol", player.musicVol);
    }

    private void OnEnable()
    {
        if(musicSlide != null)
            musicSlide.value = player.musicVol;
        if (sfxSlide != null)
            sfxSlide.value = player.sfxVol;
        if (xSensSlide != null)
            xSensSlide.value = player.xSens;
        if (ySensSlide != null)
            ySensSlide.value = player.ySens;

    }


    /*public void updateXSens(float arg)
    {
        xSens.text = (CameraControl.changeX(arg) / 10).ToString();
    }

    public void updateYSens(float arg)
    {
        ySens.text = (CameraControl.changeY(arg) / 10).ToString();
    }*/

    public void changeScene(int arg)
    {
        StartCoroutine(sceneTransition(arg));
    }

    IEnumerator sceneTransition(int arg)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(arg);
        

        while (!operation.isDone)
        {
            
            yield return null;
        }
    }

    public void selectClass()
    {
        
        gameClass.abil1 = classObj.abil1;
        gameClass.abil2 = classObj.abil2;
        gameClass.gun1 = classObj.gun1;
        gameClass.gun2 = classObj.gun2;
    }

    public void changeAudioVol(string name)
    {
        float volume;

        if (name == "SFXVol")
        {
            volume = sfxSlide.value;
            player.sfxVol = volume;
        }
        else
        {
            volume = musicSlide.value;
            player.musicVol = volume;
        }
        mixer.SetFloat(name, volume);
    }

    public void changeXSens()
    {
        float volume = xSensSlide.value;
        player.xSens = volume;
    }

    public void changeYSens()
    {
        float volume = ySensSlide.value;
        player.ySens = volume;
    }

    public void resumeGame()
    {
        PlayerUIHandler.pauseState(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameStateManager.resumeGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
