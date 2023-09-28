//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/_Core/Modules/CustomCursor/CursorInput.inputactions
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

public partial class @CursorInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CursorInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CursorInput"",
    ""maps"": [
        {
            ""name"": ""Cursor"",
            ""id"": ""519d8d44-d04f-4aba-bbb9-e7e2ce5fe9a9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6fdf057e-957b-4fae-a5fb-e63752e10dab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Unlock"",
                    ""type"": ""Button"",
                    ""id"": ""84158ee6-ad28-485d-9d7f-e055ca8fa724"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""ee30019d-f68a-4921-b078-1ec9b45684da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow"",
                    ""id"": ""87774a5c-cf47-4fd1-9264-9eb370115c6b"",
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
                    ""id"": ""028a9949-ae62-4418-9346-0ad8c27b87b8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bcf7b64a-c904-44c9-91dc-b5341ff45416"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2bedb95e-9e3f-410d-a79e-ed1bd9e0e942"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9aae41b3-e26c-4f37-959e-72da53b1c9ca"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b8c49a72-ccf5-44d4-bf5f-e4f8432be7e5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8062fda-2065-485f-bf19-3e1e69e446c0"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d180135-3c1d-4d69-8b2e-68a951f003d0"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cursor
        m_Cursor = asset.FindActionMap("Cursor", throwIfNotFound: true);
        m_Cursor_Move = m_Cursor.FindAction("Move", throwIfNotFound: true);
        m_Cursor_Unlock = m_Cursor.FindAction("Unlock", throwIfNotFound: true);
        m_Cursor_Click = m_Cursor.FindAction("Click", throwIfNotFound: true);
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

    // Cursor
    private readonly InputActionMap m_Cursor;
    private List<ICursorActions> m_CursorActionsCallbackInterfaces = new List<ICursorActions>();
    private readonly InputAction m_Cursor_Move;
    private readonly InputAction m_Cursor_Unlock;
    private readonly InputAction m_Cursor_Click;
    public struct CursorActions
    {
        private @CursorInput m_Wrapper;
        public CursorActions(@CursorInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Cursor_Move;
        public InputAction @Unlock => m_Wrapper.m_Cursor_Unlock;
        public InputAction @Click => m_Wrapper.m_Cursor_Click;
        public InputActionMap Get() { return m_Wrapper.m_Cursor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CursorActions set) { return set.Get(); }
        public void AddCallbacks(ICursorActions instance)
        {
            if (instance == null || m_Wrapper.m_CursorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CursorActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Unlock.started += instance.OnUnlock;
            @Unlock.performed += instance.OnUnlock;
            @Unlock.canceled += instance.OnUnlock;
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
        }

        private void UnregisterCallbacks(ICursorActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Unlock.started -= instance.OnUnlock;
            @Unlock.performed -= instance.OnUnlock;
            @Unlock.canceled -= instance.OnUnlock;
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
        }

        public void RemoveCallbacks(ICursorActions instance)
        {
            if (m_Wrapper.m_CursorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICursorActions instance)
        {
            foreach (var item in m_Wrapper.m_CursorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CursorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CursorActions @Cursor => new CursorActions(this);
    public interface ICursorActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUnlock(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}