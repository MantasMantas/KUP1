using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HandManager : MonoBehaviour
{
    public Transform righHandPos;
    public OVRHand rightHand;
    public float distanceThreshold;
    public TExperimentConfiguration experimentalConfig;
    public VoidEvent HandMovementEvent;
    public Flag pinchFlag;
    public PathSO path;

    public float gainStep = 0.01f;

    private Vector3 StartingHandPosition, CurrentHandPosition;
    private bool isVibrationStarted, isVibrationEnabled;
    private bool pinchDetect, gainEnabled;

    private MovementDelta movementDelta;
    private int bufferSize = 5;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VibrationUpdate();
        GainUpdate();
        PinchUpdate();
    }

    public void ResetHandPosition() 
    {
        rightHand.transform.position = righHandPos.position;
    }

    public void SetUpBuffer() 
    {
        startingPosition = path.GetPointInPath(0.5f);
        movementDelta = new MovementDelta(startingPosition, bufferSize);
        movementDelta.InitializeBufer();
    }


    public void EnableVibration() 
    {
        isVibrationEnabled = true;
        StartingHandPosition = rightHand.transform.position;
        CurrentHandPosition = rightHand.transform.position;
    }

    public void DisableVibration() 
    {
        isVibrationEnabled = false;
        isVibrationStarted = false;
    }

    public void EnablePinchDetect() 
    {
        pinchDetect = true;
    }

    public void DisablePinchDetect() 
    {
        pinchDetect = false;
    }

    public void EnableGain() 
    {
        gainEnabled = true;
    }

    public void DisableGain() 
    {
        gainEnabled = false;
    }

    private void VibrationUpdate() 
    {
        if (!isVibrationEnabled || isVibrationStarted)

        {
            return;
        }


        if (Vector3.Distance(StartingHandPosition, CurrentHandPosition) >= distanceThreshold)
        {
            isVibrationStarted = true;
            HandMovementEvent.raiseEvent();
        }
        else
        {
            CurrentHandPosition = rightHand.transform.position;
        }
    }
    private void PinchUpdate() 
    {
        if (!pinchDetect)
        {
            return;
        }

        if (rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.5f)
        {
            //Debug.Log("Right Hand is pinching!");
            pinchFlag.EnableFlag();
        }
        else
        {
            pinchFlag.DisableFlag();
        }
    }
    private void GainUpdate() 
    {
        // Checking if there is a gain to apply
        float currentGain = experimentalConfig.GetCurrentGain();

        if(currentGain == 1 || !gainEnabled) 
        {
            return;
        }

        // Fetch the current hand position and update the buffer
        Vector3 currentPosition = righHandPos.transform.position;
        movementDelta.AddValue(currentPosition);

        // Get the movement delta
        Vector3 delta = movementDelta.CalculateAverageMovementDelta();

        // Apply the gain
        Vector3 deltaGain = delta * currentGain;

        // Apply the adjusted delta to the hand position
        rightHand.transform.position += deltaGain;


    }





}
