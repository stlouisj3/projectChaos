//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Player Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""50b253a8-44b8-491b-99d0-c559caad9920"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""353f27e2-b906-4be5-9141-175746f1bca6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f3e496e3-09be-4812-8621-120673b8c811"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""15613a56-191d-484d-a284-d2c59683bbf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b6bd18b-c6a7-4424-b688-bc6d01048cd8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""962990b3-8110-47fe-8b9c-40a5ac135fcb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""433882cd-9fc4-4136-b6b1-77d097ffe6c4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5da6d12d-6057-45bd-909d-77954efab8d1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c1e179ff-5561-4c40-89ac-8a764ec0d0f7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""340d8714-919d-45de-9288-c46414015366"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aea12bff-8609-46b1-979a-be4dff04c68b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137694a2-7062-4577-9c77-c7318ec9f28c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67f6d003-735c-4173-88a2-f7623ad58db7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db78805a-3e27-4c67-8bc6-6307cc0d9891"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7962b313-1a49-4cb6-ba69-014f178b465e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Camera Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc339004-c515-4885-9715-8ea26c255e6a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Camera Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""803b5f7c-524f-4b0b-b23a-e2cd1938d897"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a2d6b841-e662-4b05-abc0-254f1611c6f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""0295ca94-ea32-4999-8ae2-0e1d4bb1202c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""7fd82357-b37b-4d2e-93a4-3af69bb6954c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftShoot"",
                    ""type"": ""Button"",
                    ""id"": ""a76556b5-32cf-4016-b15a-1a2ee2cd644c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""765f3c5f-ec53-44da-91a2-cd56443d4d1f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71795eb1-0c46-4916-bd48-313db70b1770"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143ba3ee-bd60-44d4-a832-958852cdfa25"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41181869-0853-4f57-8543-896f8adf1166"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c540ae4f-5e4b-420c-8259-b99157c9a288"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8652ccc3-0911-4b09-b348-7d95ea57db2a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""075319fe-da8f-4b06-a89b-aace8ea81d6b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""LeftShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1c86350-438b-4fae-9c8d-3899b3719004"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuButtons"",
            ""id"": ""00954523-81ea-4afa-8b95-5f02ce3c7758"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e4ec6512-f656-4439-b5ac-cc8c9eebf1fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2c822dac-ada4-4363-8bf2-8798219ef4a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""16128997-0332-46eb-bae0-1f80cd2a21c8"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a049ad-9168-47b0-b403-b4a05ec2c2ce"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e78550ff-7e7c-44af-809f-dacfeb143cf3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Abilities"",
            ""id"": ""9de98a7d-8fcb-4d21-a42a-99f182b5438c"",
            ""actions"": [
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""7fa0e7c1-e7a9-4e25-921f-9d3e2ed95cb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""b54659d5-7dc3-4824-b344-5f6a62e1b8ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6224955b-48bd-4a65-ba1f-f9ff6b8806eb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""507a7259-5b20-44e9-baff-f075a1c24d10"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3625de6-18b3-4a59-890f-6a758810052c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d2e7a87-a644-4339-ad79-4b2e59d1791e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controls"",
            ""bindingGroup"": ""Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Sprint = m_Movement.FindAction("Sprint", throwIfNotFound: true);
        m_Movement_CameraMovement = m_Movement.FindAction("Camera Movement", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
        m_Shooting_Reload = m_Shooting.FindAction("Reload", throwIfNotFound: true);
        m_Shooting_SwitchWeapon = m_Shooting.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_Shooting_LeftShoot = m_Shooting.FindAction("LeftShoot", throwIfNotFound: true);
        // MenuButtons
        m_MenuButtons = asset.FindActionMap("MenuButtons", throwIfNotFound: true);
        m_MenuButtons_Pause = m_MenuButtons.FindAction("Pause", throwIfNotFound: true);
        m_MenuButtons_Cursor = m_MenuButtons.FindAction("Cursor", throwIfNotFound: true);
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_Ability1 = m_Abilities.FindAction("Ability1", throwIfNotFound: true);
        m_Abilities_Ability2 = m_Abilities.FindAction("Ability2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Sprint;
    private readonly InputAction m_Movement_CameraMovement;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Sprint => m_Wrapper.m_Movement_Sprint;
        public InputAction @CameraMovement => m_Wrapper.m_Movement_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnSprint;
                @CameraMovement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraMovement;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private IShootingActions m_ShootingActionsCallbackInterface;
    private readonly InputAction m_Shooting_Shoot;
    private readonly InputAction m_Shooting_Reload;
    private readonly InputAction m_Shooting_SwitchWeapon;
    private readonly InputAction m_Shooting_LeftShoot;
    public struct ShootingActions
    {
        private @PlayerControls m_Wrapper;
        public ShootingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
        public InputAction @Reload => m_Wrapper.m_Shooting_Reload;
        public InputAction @SwitchWeapon => m_Wrapper.m_Shooting_SwitchWeapon;
        public InputAction @LeftShoot => m_Wrapper.m_Shooting_LeftShoot;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void SetCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnReload;
                @SwitchWeapon.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnSwitchWeapon;
                @LeftShoot.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnLeftShoot;
                @LeftShoot.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnLeftShoot;
                @LeftShoot.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnLeftShoot;
            }
            m_Wrapper.m_ShootingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @LeftShoot.started += instance.OnLeftShoot;
                @LeftShoot.performed += instance.OnLeftShoot;
                @LeftShoot.canceled += instance.OnLeftShoot;
            }
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);

    // MenuButtons
    private readonly InputActionMap m_MenuButtons;
    private IMenuButtonsActions m_MenuButtonsActionsCallbackInterface;
    private readonly InputAction m_MenuButtons_Pause;
    private readonly InputAction m_MenuButtons_Cursor;
    public struct MenuButtonsActions
    {
        private @PlayerControls m_Wrapper;
        public MenuButtonsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_MenuButtons_Pause;
        public InputAction @Cursor => m_Wrapper.m_MenuButtons_Cursor;
        public InputActionMap Get() { return m_Wrapper.m_MenuButtons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuButtonsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuButtonsActions instance)
        {
            if (m_Wrapper.m_MenuButtonsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnPause;
                @Cursor.started -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_MenuButtonsActionsCallbackInterface.OnCursor;
            }
            m_Wrapper.m_MenuButtonsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
            }
        }
    }
    public MenuButtonsActions @MenuButtons => new MenuButtonsActions(this);

    // Abilities
    private readonly InputActionMap m_Abilities;
    private IAbilitiesActions m_AbilitiesActionsCallbackInterface;
    private readonly InputAction m_Abilities_Ability1;
    private readonly InputAction m_Abilities_Ability2;
    public struct AbilitiesActions
    {
        private @PlayerControls m_Wrapper;
        public AbilitiesActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability1 => m_Wrapper.m_Abilities_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Abilities_Ability2;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterface != null)
            {
                @Ability1.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAbility2;
            }
            m_Wrapper.m_AbilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
            }
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);
    private int m_ControlsSchemeIndex = -1;
    public InputControlScheme ControlsScheme
    {
        get
        {
            if (m_ControlsSchemeIndex == -1) m_ControlsSchemeIndex = asset.FindControlSchemeIndex("Controls");
            return asset.controlSchemes[m_ControlsSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnLeftShoot(InputAction.CallbackContext context);
    }
    public interface IMenuButtonsActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
    }
    public interface IAbilitiesActions
    {
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
    }
}
