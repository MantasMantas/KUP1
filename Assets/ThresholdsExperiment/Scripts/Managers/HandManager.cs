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
        float CurrentGain = experimentalConfig.GetCurrentGain();

        if(CurrentGain == 1 || !gainEnabled) 
        {
            return;
        }

        // Fetching all the necessary variables for calculation
        float targetPoint = experimentalConfig.GetCurrentTarget();
        float currentPointOnPath = path.GetClosestCurveValue(righHandPos.position);

        // calculating the normalized distance used for linear interpolation
        float normalizedDistance = Mathf.InverseLerp(targetPoint, 0.5f, currentPointOnPath);

        // calulating the gain based on current distance to target
        float AppliedGain = Mathf.Lerp(1, CurrentGain, normalizedDistance);
        float gainPointOnPath = AppliedGain * currentPointOnPath;

        // applying the gain to the hand
        rightHand.transform.position = path.GetPointInPath(gainPointOnPath);
        //rightHand.transform.rotation = path.GetRotationInPath(gainPointOnPath);

    }
   
}
