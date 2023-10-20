using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class controllerFix : MonoBehaviour
{
    private GamepadMouseCursorUIActions uiInput;

    [SerializeField]
    private InputSystemUIInputModule UIsystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIsystem.actionsAsset = uiInput.asset;
        UIsystem.point = InputActionReference.Create(uiInput.UI.Point);
        UIsystem.leftClick = InputActionReference.Create(uiInput.UI.Click);
    }
}
