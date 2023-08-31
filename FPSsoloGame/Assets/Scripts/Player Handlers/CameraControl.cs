using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    IEnumerator camCon()
    {
        while (gameStateManager.currState())
        {
        float mouseX = input.getLook().x * Time.deltaTime * player.xSens;
        float mouseY = input.getLook().y * Time.deltaTime * player.ySens;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

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
