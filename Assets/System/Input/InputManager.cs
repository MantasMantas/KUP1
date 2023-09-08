using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // external dependancies
    public InputReader inputReader;
    public VoidEvent triggerPress, thumbstickPressEvent;
    public Vector2Event thumbstickMove;

    void OnEnable()
    {
        inputReader.EnableInputParticipant();
        inputReader.TriggerInput += triggerInput;
        inputReader.ThumbstickInput += thumbstickInput;
        inputReader.ThumbstickPress+= thumbstickPress;
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
}
