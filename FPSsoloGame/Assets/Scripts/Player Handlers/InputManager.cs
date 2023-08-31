using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Input", menuName = "Input")]
public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;


    private void Awake()
    {
        playerControls = new PlayerControls();
        
    }
    private void OnEnable()
    {
        playerControls.Enable();

    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 getPlayerMovement()
    {
        
        return playerControls.Movement.Move.ReadValue<Vector2>();
    }

    public Vector2 getLook()
    {
        
        return playerControls.Movement.CameraMovement.ReadValue<Vector2>();
    }
    public bool getJump()
    {
        return playerControls.Movement.Jump.triggered;
    }
    
    public float getSprint()
    {
        return playerControls.Movement.Sprint.ReadValue<float>();
    }

    public float getShoot()
    {
        return playerControls.Shooting.Shoot.ReadValue<float>();
    }

    public bool getReload()
    {
        return playerControls.Shooting.Reload.triggered;
    }

    public bool getSwitch()
    {
        return playerControls.Shooting.SwitchWeapon.triggered;
    }

    public bool getPause()
    {
        return playerControls.MenuButtons.Pause.triggered;
    }

    public float getRightShoot()
    {
        return playerControls.Shooting.LeftShoot.ReadValue<float>();
    }

    public bool getAbilityOne()
    {
        return playerControls.Abilities.Ability1.triggered;
    }

    public bool getAbilityTwo()
    {
        return playerControls.Abilities.Ability2.triggered;
    }

    public Vector2 getCursor()
    {
        return playerControls.MenuButtons.Cursor.ReadValue<Vector2>();
    }
    
}
