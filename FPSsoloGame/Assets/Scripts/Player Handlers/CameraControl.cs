using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class CameraControl : MonoBehaviour
{
    //[SerializeField]
    private float sensX;

    //[SerializeField]
    private float sensY;

    [SerializeField]
    private Transform orientation;

    private float xRotation;
    private float yRotation;

    [SerializeField]
    private InputManager input;

    [SerializeField]
    private PlayerInput controls;

    private string previousControlScheme = "";
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";
    private int controlerRate = 25;
    private int rate = 1;

    public PlayerSaveData player;

    public delegate float updateSens(float arg);
    public static updateSens changeX;
    public static updateSens changeY;

    public delegate void moveCam();
    public static moveCam camMove;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sensX = player.xSens;
        sensY = player.ySens;

        changeX = updateXSens;
        changeY = updateYSens;

        camMove = moveCamera;
    }

    private void moveCamera()
    {
        StartCoroutine(camCon());
    }

    private void OnControlChanged(PlayerInput arg)
    {
        if (controls.currentControlScheme == gamepadScheme && previousControlScheme != gamepadScheme)
        {
            Debug.Log("Controller Using");
            rate = controlerRate;
            previousControlScheme = gamepadScheme;
        }
        else if (controls.currentControlScheme == mouseScheme && previousControlScheme != mouseScheme)
        {

            Debug.Log("Mouse Using");
            rate = 1;
            previousControlScheme = mouseScheme;
        }
    }
    IEnumerator camCon()
    {
        while (gameStateManager.currState())
        {

            if (previousControlScheme != controls.currentControlScheme)
            {
                OnControlChanged(controls);
            }
            previousControlScheme = controls.currentControlScheme;
            
        float mouseX = input.getLook().x * Time.deltaTime * player.xSens * rate;
        float mouseY = input.getLook().y * Time.deltaTime * player.ySens * rate;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            //print(sensX + " " + sensY);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        yield return new WaitForFixedUpdate();
        }
        
    }
    // Update is called once per frame
   

    private float updateXSens(float arg)
    {
        player.xSens += arg; 
        sensX = player.xSens;
        return sensX;
    }

    private float updateYSens(float arg)
    {
        player.ySens += arg;
        sensY = player.ySens;
        return sensY;
    }
}
