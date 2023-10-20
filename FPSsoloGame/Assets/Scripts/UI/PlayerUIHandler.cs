using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField]
    private InputManager input;

    [SerializeField]
    private GameObject pauseMenu;

    

    private bool isPaused;

   

    public delegate void changePause(bool arg);
    public static changePause pauseState;

    private void Awake()
    {
        pauseState = setPause;
        
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        
    }


    private void setPause(bool arg)
    {
        isPaused = arg;
    }
    void Update()
    {

        
        if (input.getPause())
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStateManager.resumeGame();
                
            }
            else
            {
                isPaused = true;
                
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                gameStateManager.pauseGame();
            }
        }
    }
}
