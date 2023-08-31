using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class controllerCursor : MonoBehaviour
{
    
    [SerializeField]
    private PlayerInput playInput;
    [SerializeField]
    private RectTransform currsorTransform;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float cursorSpeed = 1000f;
    [SerializeField]
    private float padding = 35f;

    private bool previousMouseState;
    private Mouse virtualMouse;
    private Mouse currentMouse;
    private Camera mainCamera;

    private string previousControlScheme = "";
    private const string gamepadScheme = "Gamepad";
    private const string mouseScheme = "Keyboard&Mouse";

    private void OnEnable()
    {
        mainCamera = Camera.main;
        currentMouse = Mouse.current;
        InputDevice virtualMouseInputDevice = InputSystem.GetDevice("VirtualMouse");

        if(virtualMouseInputDevice == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");

        }else if (!virtualMouseInputDevice.added)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else
        {
            virtualMouse = (Mouse)virtualMouseInputDevice;
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playInput.user);
        
        if(currsorTransform != null)
        {
            Vector2 position = currsorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
        playInput.onControlsChanged += OnControlChanged;

    }

    private void OnDisable()
    {
        if(virtualMouse != null && virtualMouse.added)
            InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
        playInput.onControlsChanged -= OnControlChanged;
    }

    private void UpdateMotion()
    {
        if(virtualMouse == null || Gamepad.current == null)
        {
            return;
        }

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = virtualMouse.position.ReadValue();
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, padding, Screen.width - padding);
        newPosition.y= Mathf.Clamp(newPosition.y, padding, Screen.height - padding);

        InputState.Change(virtualMouse.position, newPosition);
        InputState.Change(virtualMouse.delta, deltaValue);


        bool abutt = Gamepad.current.buttonSouth.isPressed;
        
        if(previousMouseState != abutt)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, abutt);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = abutt;
        }

        AnchorCursor(newPosition);

    }

    private void AnchorCursor(Vector2 pos)
    {
        Vector2 anchorPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform,pos,canvas.renderMode == RenderMode.ScreenSpaceOverlay ? 
            null: mainCamera, out anchorPosition);

        currsorTransform.anchoredPosition = anchorPosition;
    }

    private void OnControlChanged(PlayerInput input)
    {
        if(playInput.currentControlScheme == mouseScheme && previousControlScheme != mouseScheme)
        {
            currsorTransform.gameObject.SetActive(false);
            Cursor.visible = true;
            currentMouse.WarpCursorPosition(virtualMouse.position.ReadValue());

            previousControlScheme = mouseScheme;
        }else if(playInput.currentControlScheme == gamepadScheme && previousControlScheme != gamepadScheme)
        {
            currsorTransform.gameObject.SetActive(true);
            Cursor.visible = false;
            InputState.Change(virtualMouse.position, currentMouse.position.ReadValue());
            AnchorCursor(currentMouse.position.ReadValue());
            previousControlScheme = gamepadScheme;
        }
    }

    private void Update()
    {
        if(previousControlScheme != playInput.currentControlScheme)
        {
            OnControlChanged(playInput);
        }
        previousControlScheme = playInput.currentControlScheme;
    }

}
