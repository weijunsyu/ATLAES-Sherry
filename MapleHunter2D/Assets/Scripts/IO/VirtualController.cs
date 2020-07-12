// GENERATED AUTOMATICALLY FROM 'Assets/IO/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VirtualController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VirtualController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Character"",
            ""id"": ""857945f0-6bf3-462f-a610-4d2fbdf172a2"",
            ""actions"": [
                {
                    ""name"": ""Strafe Left"",
                    ""type"": ""Value"",
                    ""id"": ""39ea9cdc-c2a8-4003-92a6-bf39f3c0d7a6"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Strafe Right"",
                    ""type"": ""Value"",
                    ""id"": ""44f2295f-4282-40e8-81be-70d669e2618f"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ade8005d-af26-4c78-8fb4-1118c7874b03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""817c8498-8d8b-4a94-897e-d72201e01a87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""382a9798-3913-4ecf-b9cb-142f3d6c4a6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""673d9c7f-b29f-4b25-a3e1-82c4a64d54d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""286d09a2-3182-468f-83e4-53e5f5af8975"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3bb27e9e-5eae-4862-a62f-cbbe104ac8ef"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7133c8df-a8fc-4341-997a-fee305e27c3c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51d1bdc5-5742-4c3a-bc4f-1998f3fb3dcb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca05347f-d0ca-4a3b-b1c7-7b399ea9cf99"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa126b16-2121-4c8d-8e6b-ef04701e7839"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab96d5f5-c60b-4067-8d72-ecf5bb809a52"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""386a3106-ef3b-46dd-a1ce-68138aa8a3d0"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XBox Style Controller"",
            ""bindingGroup"": ""XBox Style Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Character
        m_PlayerCharacter = asset.FindActionMap("Player Character", throwIfNotFound: true);
        m_PlayerCharacter_StrafeLeft = m_PlayerCharacter.FindAction("Strafe Left", throwIfNotFound: true);
        m_PlayerCharacter_StrafeRight = m_PlayerCharacter.FindAction("Strafe Right", throwIfNotFound: true);
        m_PlayerCharacter_Jump = m_PlayerCharacter.FindAction("Jump", throwIfNotFound: true);
        m_PlayerCharacter_MoveLeft = m_PlayerCharacter.FindAction("Move Left", throwIfNotFound: true);
        m_PlayerCharacter_MoveRight = m_PlayerCharacter.FindAction("Move Right", throwIfNotFound: true);
        m_PlayerCharacter_Crouch = m_PlayerCharacter.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerCharacter_Dash = m_PlayerCharacter.FindAction("Dash", throwIfNotFound: true);
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

    // Player Character
    private readonly InputActionMap m_PlayerCharacter;
    private IPlayerCharacterActions m_PlayerCharacterActionsCallbackInterface;
    private readonly InputAction m_PlayerCharacter_StrafeLeft;
    private readonly InputAction m_PlayerCharacter_StrafeRight;
    private readonly InputAction m_PlayerCharacter_Jump;
    private readonly InputAction m_PlayerCharacter_MoveLeft;
    private readonly InputAction m_PlayerCharacter_MoveRight;
    private readonly InputAction m_PlayerCharacter_Crouch;
    private readonly InputAction m_PlayerCharacter_Dash;
    public struct PlayerCharacterActions
    {
        private @VirtualController m_Wrapper;
        public PlayerCharacterActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @StrafeLeft => m_Wrapper.m_PlayerCharacter_StrafeLeft;
        public InputAction @StrafeRight => m_Wrapper.m_PlayerCharacter_StrafeRight;
        public InputAction @Jump => m_Wrapper.m_PlayerCharacter_Jump;
        public InputAction @MoveLeft => m_Wrapper.m_PlayerCharacter_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_PlayerCharacter_MoveRight;
        public InputAction @Crouch => m_Wrapper.m_PlayerCharacter_Crouch;
        public InputAction @Dash => m_Wrapper.m_PlayerCharacter_Dash;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCharacterActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterActionsCallbackInterface != null)
            {
                @StrafeLeft.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeLeft;
                @StrafeLeft.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeLeft;
                @StrafeLeft.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeLeft;
                @StrafeRight.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeRight;
                @StrafeRight.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeRight;
                @StrafeRight.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnStrafeRight;
                @Jump.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @MoveLeft.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @Crouch.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnCrouch;
                @Dash.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_PlayerCharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StrafeLeft.started += instance.OnStrafeLeft;
                @StrafeLeft.performed += instance.OnStrafeLeft;
                @StrafeLeft.canceled += instance.OnStrafeLeft;
                @StrafeRight.started += instance.OnStrafeRight;
                @StrafeRight.performed += instance.OnStrafeRight;
                @StrafeRight.canceled += instance.OnStrafeRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public PlayerCharacterActions @PlayerCharacter => new PlayerCharacterActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_XBoxStyleControllerSchemeIndex = -1;
    public InputControlScheme XBoxStyleControllerScheme
    {
        get
        {
            if (m_XBoxStyleControllerSchemeIndex == -1) m_XBoxStyleControllerSchemeIndex = asset.FindControlSchemeIndex("XBox Style Controller");
            return asset.controlSchemes[m_XBoxStyleControllerSchemeIndex];
        }
    }
    public interface IPlayerCharacterActions
    {
        void OnStrafeLeft(InputAction.CallbackContext context);
        void OnStrafeRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
