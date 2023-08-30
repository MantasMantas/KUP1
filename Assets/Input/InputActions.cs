//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/InputActions.inputactions
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
            ""actions"": [],
            ""bindings"": []
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
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""28d8077c-3de3-4673-abdd-812d695cfde6"",
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
                    ""id"": ""fc1383c4-ea2d-433f-9c79-68dceeab7e06"",
                    ""path"": ""<OculusTouchController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger"",
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
        // Participant
        m_Participant = asset.FindActionMap("Participant", throwIfNotFound: true);
        m_Participant_Thumbstick = m_Participant.FindAction("Thumbstick", throwIfNotFound: true);
        m_Participant_Trigger = m_Participant.FindAction("Trigger", throwIfNotFound: true);
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
    public struct ExperimentorActions
    {
        private @InputActions m_Wrapper;
        public ExperimentorActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Experimentor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExperimentorActions set) { return set.Get(); }
        public void AddCallbacks(IExperimentorActions instance)
        {
            if (instance == null || m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ExperimentorActionsCallbackInterfaces.Add(instance);
        }

        private void UnregisterCallbacks(IExperimentorActions instance)
        {
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
    private readonly InputAction m_Participant_Trigger;
    public struct ParticipantActions
    {
        private @InputActions m_Wrapper;
        public ParticipantActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thumbstick => m_Wrapper.m_Participant_Thumbstick;
        public InputAction @Trigger => m_Wrapper.m_Participant_Trigger;
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
            @Trigger.started += instance.OnTrigger;
            @Trigger.performed += instance.OnTrigger;
            @Trigger.canceled += instance.OnTrigger;
        }

        private void UnregisterCallbacks(IParticipantActions instance)
        {
            @Thumbstick.started -= instance.OnThumbstick;
            @Thumbstick.performed -= instance.OnThumbstick;
            @Thumbstick.canceled -= instance.OnThumbstick;
            @Trigger.started -= instance.OnTrigger;
            @Trigger.performed -= instance.OnTrigger;
            @Trigger.canceled -= instance.OnTrigger;
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
    public interface IExperimentorActions
    {
    }
    public interface IParticipantActions
    {
        void OnThumbstick(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
    }
}
