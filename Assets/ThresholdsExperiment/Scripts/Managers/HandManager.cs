using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HandManager : MonoBehaviour
{
    public Transform realHand;
    public OVRHand virtualHand;
    public float distanceThreshold;
    public TExperimentConfiguration experimentalConfig;
    public VoidEvent HandMovementEvent;
    public Flag pinchFlag;
    public PathSO path;

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

    public void ResetHandPosition() 
    {
        virtualHand.transform.position = realHand.position;
    }

    public void EnableVibration() 
    {
        isVibrationEnabled = true;
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
        StartingHandPosition = realHand.transform.position;
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
            CurrentHandPosition = realHand.transform.position;
        }
    }
    private void PinchUpdate() 
    {
        if (!pinchDetect)
        {
            return;
        }

        if (virtualHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.5f)
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
        float gain = experimentalConfig.GetCurrentGain();

        if(gain == 1 || !gainEnabled) 
        {
            return;
        }

        Debug.Log("The gain is: " + gain);
        virtualHand.transform.position = GainWarp(realHand.position, StartingHandPosition, gain);

        
    }

    private Vector3 GainWarp(Vector3 pr, Vector3 o, float g)
    {
        Vector3 dr = pr - o; // Unwarped offset from origin
        Vector3 dv = g * dr; // Warped offset from origin
        Vector3 pv = o + dv; // Final warped position

        return pv;
    }






}
