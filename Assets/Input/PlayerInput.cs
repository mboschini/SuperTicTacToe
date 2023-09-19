// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d4f3c1d3-f4b2-4c87-b7d9-eb41496ac3c4"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""fecd38cb-1393-41f9-8e31-03ae19ce0aab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plus"",
                    ""type"": ""Button"",
                    ""id"": ""164e9584-b530-4b84-ac56-ab0f4cc12f30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""63d5e6e0-9c11-49e8-9bd5-b91d78c7f0d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""62aff2dc-d615-4823-add3-f3309be68c33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9c4c0e92-d279-4a31-a41f-1b5a86ff261a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""750855a6-4233-427d-bed4-7f2c1b21d2ce"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05fa33a-9a0e-432f-84dc-1acd78a6b150"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9736e674-bede-427f-9af6-a4b6ed6e8bd6"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""838fbf9f-3f73-49fc-b5fa-6742e8d7c78b"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a42a638c-5f3c-4b1e-a9f4-cfaaffda3a17"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Click = m_Gameplay.FindAction("Click", throwIfNotFound: true);
        m_Gameplay_Plus = m_Gameplay.FindAction("Plus", throwIfNotFound: true);
        m_Gameplay_TouchInput = m_Gameplay.FindAction("TouchInput", throwIfNotFound: true);
        m_Gameplay_TouchPress = m_Gameplay.FindAction("TouchPress", throwIfNotFound: true);
        m_Gameplay_TouchPosition = m_Gameplay.FindAction("TouchPosition", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Click;
    private readonly InputAction m_Gameplay_Plus;
    private readonly InputAction m_Gameplay_TouchInput;
    private readonly InputAction m_Gameplay_TouchPress;
    private readonly InputAction m_Gameplay_TouchPosition;
    public struct GameplayActions
    {
        private @PlayerInput m_Wrapper;
        public GameplayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Gameplay_Click;
        public InputAction @Plus => m_Wrapper.m_Gameplay_Plus;
        public InputAction @TouchInput => m_Wrapper.m_Gameplay_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_Gameplay_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Gameplay_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Plus.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlus;
                @Plus.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlus;
                @Plus.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPlus;
                @TouchInput.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Plus.started += instance.OnPlus;
                @Plus.performed += instance.OnPlus;
                @Plus.canceled += instance.OnPlus;
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnPlus(InputAction.CallbackContext context);
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
