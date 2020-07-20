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
                    ""name"": ""Move Right"",
                    ""type"": ""Button"",
                    ""id"": ""51fccbee-d763-42c8-96a4-40001f5a663b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Left"",
                    ""type"": ""Button"",
                    ""id"": ""774d2c3d-fcc4-4d65-bf51-42b9d5c6f1f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""32a1019b-9e2c-418e-b06b-b6f2421d746d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e41f5a14-5407-48a1-ad24-d87e4ef9092b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4037f3bb-f3d5-4757-9bb2-d4e1fe0a2493"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bd1041b-c10e-46ce-b29d-406e43b86ec5"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb4b9c2-e6a9-4186-ba25-191c70220afb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9912f122-5725-494c-9e50-db35527cfd24"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move Right"",
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
        m_PlayerCharacter_MoveRight = m_PlayerCharacter.FindAction("Move Right", throwIfNotFound: true);
        m_PlayerCharacter_MoveLeft = m_PlayerCharacter.FindAction("Move Left", throwIfNotFound: true);
        m_PlayerCharacter_Jump = m_PlayerCharacter.FindAction("Jump", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerCharacter_MoveRight;
    private readonly InputAction m_PlayerCharacter_MoveLeft;
    private readonly InputAction m_PlayerCharacter_Jump;
    private readonly InputAction m_PlayerCharacter_Dash;
    public struct PlayerCharacterActions
    {
        private @VirtualController m_Wrapper;
        public PlayerCharacterActions(@VirtualController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_PlayerCharacter_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_PlayerCharacter_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_PlayerCharacter_Jump;
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
                @MoveRight.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveRight;
                @MoveLeft.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnMoveLeft;
                @Jump.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerCharacterActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_PlayerCharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
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
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
