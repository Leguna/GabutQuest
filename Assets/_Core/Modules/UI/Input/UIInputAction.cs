//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Core/UI/Input/UIInputAction.inputactions
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

public partial class @UIInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UIInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIInputAction"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""2c790ffc-d470-4c16-9c09-87bd81c7cb06"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""bd8193a5-bd5f-4bc3-9f83-79b5574cf93b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""a6b6616e-8b75-4cd2-98ff-ac79581d6e25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move Selected"",
                    ""type"": ""Value"",
                    ""id"": ""ef7058f6-9ada-47dd-a333-e3b35b2ce201"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Next Input Selected"",
                    ""type"": ""Button"",
                    ""id"": ""7b913acb-2a6a-4408-b814-7f313b7d074b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Previous Input Selected"",
                    ""type"": ""Button"",
                    ""id"": ""71f561f3-ff10-46be-a253-28fd374922a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""2a532d5e-2eb5-4756-ab3d-4deec49ae75e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Tab Next"",
                    ""type"": ""Button"",
                    ""id"": ""f9784466-781d-4634-8101-da141e726724"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tab Prev"",
                    ""type"": ""Button"",
                    ""id"": ""584d39fd-5e2c-49ec-a17f-6366b9e61527"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e260cde8-4938-4ceb-9eab-c2caf6872660"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fa6ef45-8743-4a4c-95f8-e9c4948abdc2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4acae3f4-88ad-480c-9f49-ac0584d3b59f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd54905-b174-40f5-839b-4615dcaf0ec6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""06b034f7-5e0a-4a26-a673-1bef6ff02049"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Input Selected"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5f70f756-1efd-4116-8471-db0f24167dcf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Input Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""4cb2d867-2721-48ea-90d7-58ee9331916d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Input Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b2b18cad-3d23-4dbb-aa36-2e8ab3799b74"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Input Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6431e69c-73ad-4797-a00e-4de5605b1320"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next Input Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56bdcfe0-9570-462f-8f99-c0be75c6fa35"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next Input Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD Keys"",
                    ""id"": ""ca6c5e1f-13ac-4dcc-8b27-dad58e2eff87"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selected"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""85a35b46-5be5-401b-b4b7-fdf5b73c6e3f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e407ddfa-5a21-4739-9b07-cf0aacd52aec"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e2e6e439-7d85-4b9c-8004-0e93a4debd77"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3f495e5e-a62e-409f-a7b4-201e9c83475d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Selected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""ac4b3145-a19a-4b5f-aad5-52df5cdc029f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3e9addea-43e3-4cc0-91a0-40333e8d1e9b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e86d327b-85bf-41c0-b489-5a9adb966e92"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""70ec0b8f-f479-450a-997d-04c934b3591c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""958e69e7-05f6-4205-a8a6-c7c0c14af3d6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8d59e6cd-de5a-41a1-9c62-dcd6cf61197f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02f8fce7-f872-4eec-b891-9dcf2c5a7ea6"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Prev"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Confirm = m_UI.FindAction("Confirm", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
        m_UI_MoveSelected = m_UI.FindAction("Move Selected", throwIfNotFound: true);
        m_UI_NextInputSelected = m_UI.FindAction("Next Input Selected", throwIfNotFound: true);
        m_UI_PreviousInputSelected = m_UI.FindAction("Previous Input Selected", throwIfNotFound: true);
        m_UI_Cursor = m_UI.FindAction("Cursor", throwIfNotFound: true);
        m_UI_TabNext = m_UI.FindAction("Tab Next", throwIfNotFound: true);
        m_UI_TabPrev = m_UI.FindAction("Tab Prev", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Confirm;
    private readonly InputAction m_UI_Back;
    private readonly InputAction m_UI_MoveSelected;
    private readonly InputAction m_UI_NextInputSelected;
    private readonly InputAction m_UI_PreviousInputSelected;
    private readonly InputAction m_UI_Cursor;
    private readonly InputAction m_UI_TabNext;
    private readonly InputAction m_UI_TabPrev;
    public struct UIActions
    {
        private @UIInputAction m_Wrapper;
        public UIActions(@UIInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_UI_Confirm;
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputAction @MoveSelected => m_Wrapper.m_UI_MoveSelected;
        public InputAction @NextInputSelected => m_Wrapper.m_UI_NextInputSelected;
        public InputAction @PreviousInputSelected => m_Wrapper.m_UI_PreviousInputSelected;
        public InputAction @Cursor => m_Wrapper.m_UI_Cursor;
        public InputAction @TabNext => m_Wrapper.m_UI_TabNext;
        public InputAction @TabPrev => m_Wrapper.m_UI_TabPrev;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
            @Back.started += instance.OnBack;
            @Back.performed += instance.OnBack;
            @Back.canceled += instance.OnBack;
            @MoveSelected.started += instance.OnMoveSelected;
            @MoveSelected.performed += instance.OnMoveSelected;
            @MoveSelected.canceled += instance.OnMoveSelected;
            @NextInputSelected.started += instance.OnNextInputSelected;
            @NextInputSelected.performed += instance.OnNextInputSelected;
            @NextInputSelected.canceled += instance.OnNextInputSelected;
            @PreviousInputSelected.started += instance.OnPreviousInputSelected;
            @PreviousInputSelected.performed += instance.OnPreviousInputSelected;
            @PreviousInputSelected.canceled += instance.OnPreviousInputSelected;
            @Cursor.started += instance.OnCursor;
            @Cursor.performed += instance.OnCursor;
            @Cursor.canceled += instance.OnCursor;
            @TabNext.started += instance.OnTabNext;
            @TabNext.performed += instance.OnTabNext;
            @TabNext.canceled += instance.OnTabNext;
            @TabPrev.started += instance.OnTabPrev;
            @TabPrev.performed += instance.OnTabPrev;
            @TabPrev.canceled += instance.OnTabPrev;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
            @Back.started -= instance.OnBack;
            @Back.performed -= instance.OnBack;
            @Back.canceled -= instance.OnBack;
            @MoveSelected.started -= instance.OnMoveSelected;
            @MoveSelected.performed -= instance.OnMoveSelected;
            @MoveSelected.canceled -= instance.OnMoveSelected;
            @NextInputSelected.started -= instance.OnNextInputSelected;
            @NextInputSelected.performed -= instance.OnNextInputSelected;
            @NextInputSelected.canceled -= instance.OnNextInputSelected;
            @PreviousInputSelected.started -= instance.OnPreviousInputSelected;
            @PreviousInputSelected.performed -= instance.OnPreviousInputSelected;
            @PreviousInputSelected.canceled -= instance.OnPreviousInputSelected;
            @Cursor.started -= instance.OnCursor;
            @Cursor.performed -= instance.OnCursor;
            @Cursor.canceled -= instance.OnCursor;
            @TabNext.started -= instance.OnTabNext;
            @TabNext.performed -= instance.OnTabNext;
            @TabNext.canceled -= instance.OnTabNext;
            @TabPrev.started -= instance.OnTabPrev;
            @TabPrev.performed -= instance.OnTabPrev;
            @TabPrev.canceled -= instance.OnTabPrev;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IUIActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMoveSelected(InputAction.CallbackContext context);
        void OnNextInputSelected(InputAction.CallbackContext context);
        void OnPreviousInputSelected(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnTabNext(InputAction.CallbackContext context);
        void OnTabPrev(InputAction.CallbackContext context);
    }
}
