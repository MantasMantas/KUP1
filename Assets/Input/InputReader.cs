using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader/New Input Reader")]
public class InputReader : ScriptableObject, InputActions.IExperimentorActions, InputActions.IParticipantActions
{
    // internal variables
    private InputActions inputActions;

    // events that act as relays
    public event UnityAction<Vector2> ThumbstickInput = delegate { };
    public event UnityAction TriggerInput = delegate { };
    void OnEnable() 
    {
        if(inputActions == null) 
        {
            inputActions = new InputActions();
            inputActions.Experimentor.SetCallbacks(this);
            inputActions.Participant.SetCallbacks(this);
        }
    }

    public void EnableInputExperimentor()
    {
        inputActions.Experimentor.Enable();
        inputActions.Participant.Disable();
    }

    public void EnableInputParticipant()
    {
        inputActions.Experimentor.Disable();
        inputActions.Participant.Enable();
    }

    public void DisableInput() 
    {
        inputActions.Experimentor.Disable();
        inputActions.Participant.Disable();
    }

    public void OnThumbstick(InputAction.CallbackContext context) 
    {
        ThumbstickInput.Invoke(context.ReadValue<Vector2>());
    }

    public void OnTrigger(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed) 
        {
            TriggerInput.Invoke();
        }
    }
}
