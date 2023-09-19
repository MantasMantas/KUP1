using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // external dependancies
    public InputReader inputReader;
    public VoidEvent triggerPress, thumbstickPressEvent;
    public Vector2Event thumbstickMove;
    public Vector3Event ControllerMove;

    void OnEnable()
    {
        inputReader.EnableInputExperimentor();
        inputReader.TriggerInput += triggerInput;
        inputReader.ThumbstickInput += thumbstickInput;
        inputReader.ThumbstickPress += thumbstickPress;
        inputReader.ControllerMove += ControllerInput;
    }

    void OnDisable()
    {
        inputReader.TriggerInput -= triggerInput;
        inputReader.ThumbstickInput -= thumbstickInput;
    }

    private void triggerInput() 
    {
        triggerPress.raiseEvent();
    }

    private void thumbstickInput(Vector2 value) 
    {
        thumbstickMove.raiseEvent(value);
    }

    private void thumbstickPress() 
    {
        thumbstickPressEvent.raiseEvent();
    }

    private void ControllerInput(Vector3 value) 
    {
        ControllerMove.raiseEvent(value);
    }

    public void EnableExpControl() 
    {
        inputReader.EnableInputExperimentor();
    }

    public void EnablePartControl() 
    {
        inputReader.EnableInputParticipant();
    }
}
