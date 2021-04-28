// GENERATED AUTOMATICALLY FROM 'Assets/IO/MenuControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuControls"",
    ""maps"": [
        {
            ""name"": ""Menu Actions"",
            ""id"": ""06860ef1-d274-494d-aa11-2450b9c02eea"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""3150017c-7a0a-4827-8ca2-4638b0bcf3d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""6124dfd7-4ca1-4136-bfc9-7967322178e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""92e48307-1ac2-4614-ac64-9b5c4b4247a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""d58f6671-95ec-4f72-9973-cc5823ae088c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""52245aa3-c348-450e-8f4a-b610b677b1c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20248c43-ee09-4f22-be6d-4cba1f58d8b3"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a216c507-c2e6-4bfa-9ffa-6e36b6b56501"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2b50f5a-b96d-4cc0-afc0-afc5d852316a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d24d4fc8-63bf-408d-85d7-af9b294b4d3f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba2fff50-8ffc-4d79-a5ea-01f4438ad93d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu Actions
        m_MenuActions = asset.FindActionMap("Menu Actions", throwIfNotFound: true);
        m_MenuActions_Select = m_MenuActions.FindAction("Select", throwIfNotFound: true);
        m_MenuActions_Up = m_MenuActions.FindAction("Up", throwIfNotFound: true);
        m_MenuActions_Down = m_MenuActions.FindAction("Down", throwIfNotFound: true);
        m_MenuActions_Left = m_MenuActions.FindAction("Left", throwIfNotFound: true);
        m_MenuActions_Right = m_MenuActions.FindAction("Right", throwIfNotFound: true);
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

    // Menu Actions
    private readonly InputActionMap m_MenuActions;
    private IMenuActionsActions m_MenuActionsActionsCallbackInterface;
    private readonly InputAction m_MenuActions_Select;
    private readonly InputAction m_MenuActions_Up;
    private readonly InputAction m_MenuActions_Down;
    private readonly InputAction m_MenuActions_Left;
    private readonly InputAction m_MenuActions_Right;
    public struct MenuActionsActions
    {
        private @MenuControls m_Wrapper;
        public MenuActionsActions(@MenuControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MenuActions_Select;
        public InputAction @Up => m_Wrapper.m_MenuActions_Up;
        public InputAction @Down => m_Wrapper.m_MenuActions_Down;
        public InputAction @Left => m_Wrapper.m_MenuActions_Left;
        public InputAction @Right => m_Wrapper.m_MenuActions_Right;
        public InputActionMap Get() { return m_Wrapper.m_MenuActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActionsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActionsActions instance)
        {
            if (m_Wrapper.m_MenuActionsActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnSelect;
                @Up.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MenuActionsActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_MenuActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public MenuActionsActions @MenuActions => new MenuActionsActions(this);
    public interface IMenuActionsActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
