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

    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
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
