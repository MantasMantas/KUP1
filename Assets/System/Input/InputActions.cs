//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/System/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Experimentor"",
            ""id"": ""67659982-d3c7-43d3-9b06-d51205cbab74"",
            ""actions"": [
                {
                    ""name"": ""ControllerMove"",
                    ""type"": ""Value"",
                    ""id"": ""8afec6ae-edce-4431-af9a-b4b5efa48edc"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""dd0b754c-d7e5-4bf2-8826-9fca3d32a651"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9d9b7092-23cc-4b51-bbb5-88d0d38ea0f6"",
                    ""path"": ""<OculusTouchController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47ac7944-882f-4fb6-9928-6b8bcdb885c9"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/triggerpressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Participant"",
            ""id"": ""bda3fcd7-a536-4343-a3f5-a4506f807ac2"",
            ""actions"": [
                {
                    ""name"": ""Thumbstick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0b33acaa-9d1d-4666-a2e7-b2063c345c6d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ThumbstickPress"",
                    ""type"": ""Button"",
                    ""id"": ""41e47695-637a-4d20-ba72-218743451ff3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""281278e3-6b6a-46c2-a3d4-d8eba60cc708"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thumbstick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c51334d2-97d9-4dbd-aa7f-221b7bd45673"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/thumbstickclicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThumbstickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""4b9d97f8-43ee-4c6b-8dde-607dc0457508"",
            ""actions"": [
                {
                    ""name"": ""Spacebar"",
                    ""type"": ""Button"",
                    ""id"": ""52f28307-431a-4be2-97c2-3c4e58707fdf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9808315d-7e49-4b25-9b34-507aefe8d673"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spacebar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Experimentor
        m_Experimentor = asset.FindActionMap("Experimentor", throwIfNotFound: true);
        m_Experimentor_ControllerMove = m_Experimentor.FindAction("ControllerMove", throwIfNotFound: true);
        m_Experimentor_Trigger = m_Experimentor.FindAction("Trigger", throwIfNotFound: true);
        // Participant
        m_Participant = asset.FindActionMap("Participant", throwIfNotFound: true);
        m_Participant_Thumbstick = m_Participant.FindAction("Thumbstick", throwIfNotFound: true);
        m_Participant_ThumbstickPress = m_Participant.FindAction("ThumbstickPress", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Spacebar = m_Keyboard.FindAction("Spacebar", throwIfNotFound: true);
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

    // Experimentor
    private readonly InputActionMap m_Experimentor;
    private List<IExperimentorActions> m_ExperimentorActionsCallbackInterfaces = new List<IExperimentorActions>();
    private readonly InputAction m_Experimentor_ControllerMove;
    private readonly InputAction m_Experimentor_Trigger;
    public struct ExperimentorActions
    {
        private @InputActions m_Wrapper;
        public ExperimentorActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ControllerMove => m_Wrapper.m_Experimentor_ControllerMove;
        public InputAction @Trigger => m_Wrapper.m_Experimentor_Trigger;
        public InputActionMap Get() { return m_Wrapper.m_Experimentor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExperimentorActions set) { return set.Get(); }
        public void AddCallbacks(IExperimentorActions instance)
        {
            if (instance == null || m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Add(instance);
            @ControllerMove.started += instance.OnControllerMove;
            @ControllerMove.performed += instance.OnControllerMove;
            @ControllerMove.canceled += instance.OnControllerMove;
            @Trigger.started += instance.OnTrigger;
            @Trigger.performed += instance.OnTrigger;
            @Trigger.canceled += instance.OnTrigger;
        }

        private void UnregisterCallbacks(IExperimentorActions instance)
        {
            @ControllerMove.started -= instance.OnControllerMove;
            @ControllerMove.performed -= instance.OnControllerMove;
            @ControllerMove.canceled -= instance.OnControllerMove;
            @Trigger.started -= instance.OnTrigger;
            @Trigger.performed -= instance.OnTrigger;
            @Trigger.canceled -= instance.OnTrigger;
        }

        public void RemoveCallbacks(IExperimentorActions instance)
        {
            if (m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IExperimentorActions instance)
        {
            foreach (var item in m_Wrapper.m_ExperimentorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ExperimentorActions @Experimentor => new ExperimentorActions(this);

    // Participant
    private readonly InputActionMap m_Participant;
    private List<IParticipantActions> m_ParticipantActionsCallbackInterfaces = new List<IParticipantActions>();
    private readonly InputAction m_Participant_Thumbstick;
    private readonly InputAction m_Participant_ThumbstickPress;
    public struct ParticipantActions
    {
        private @InputActions m_Wrapper;
        public ParticipantActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thumbstick => m_Wrapper.m_Participant_Thumbstick;
        public InputAction @ThumbstickPress => m_Wrapper.m_Participant_ThumbstickPress;
        public InputActionMap Get() { return m_Wrapper.m_Participant; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ParticipantActions set) { return set.Get(); }
        public void AddCallbacks(IParticipantActions instance)
        {
            if (instance == null || m_Wrapper.m_ParticipantActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ParticipantActionsCallbackInterfaces.Add(instance);
            @Thumbstick.started += instance.OnThumbstick;
            @Thumbstick.performed += instance.OnThumbstick;
            @Thumbstick.canceled += instance.OnThumbstick;
            @ThumbstickPress.started += instance.OnThumbstickPress;
            @ThumbstickPress.performed += instance.OnThumbstickPress;
            @ThumbstickPress.canceled += instance.OnThumbstickPress;
        }

        private void UnregisterCallbacks(IParticipantActions instance)
        {
            @Thumbstick.started -= instance.OnThumbstick;
            @Thumbstick.performed -= instance.OnThumbstick;
            @Thumbstick.canceled -= instance.OnThumbstick;
            @ThumbstickPress.started -= instance.OnThumbstickPress;
            @ThumbstickPress.performed -= instance.OnThumbstickPress;
            @ThumbstickPress.canceled -= instance.OnThumbstickPress;
        }

        public void RemoveCallbacks(IParticipantActions instance)
        {
            if (m_Wrapper.m_ParticipantActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IParticipantActions instance)
        {
            foreach (var item in m_Wrapper.m_ParticipantActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ParticipantActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ParticipantActions @Participant => new ParticipantActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private List<IKeyboardActions> m_KeyboardActionsCallbackInterfaces = new List<IKeyboardActions>();
    private readonly InputAction m_Keyboard_Spacebar;
    public struct KeyboardActions
    {
        private @InputActions m_Wrapper;
        public KeyboardActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Spacebar => m_Wrapper.m_Keyboard_Spacebar;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Add(instance);
            @Spacebar.started += instance.OnSpacebar;
            @Spacebar.performed += instance.OnSpacebar;
            @Spacebar.canceled += instance.OnSpacebar;
        }

        private void UnregisterCallbacks(IKeyboardActions instance)
        {
            @Spacebar.started -= instance.OnSpacebar;
            @Spacebar.performed -= instance.OnSpacebar;
            @Spacebar.canceled -= instance.OnSpacebar;
        }

        public void RemoveCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IExperimentorActions
    {
        void OnControllerMove(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
    }
    public interface IParticipantActions
    {
        void OnThumbstick(InputAction.CallbackContext context);
        void OnThumbstickPress(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnSpacebar(InputAction.CallbackContext context);
    }
}
