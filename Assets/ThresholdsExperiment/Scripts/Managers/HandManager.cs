using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HandManager : MonoBehaviour
{
    public OVRHand rightHand;
    public Transform rightHandT;
    public float distanceThreshold;
    public TExperimentConfiguration experimentalConfig;
    public VoidEvent HandMovementEvent;
    public Flag pinchFlag;
    public PathSO path;

    private Vector3 StartingHandPosition, CurrentHandPosition;
    private bool isVibrationStarted, isVibrationEnabled;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        VibrationUpdate();

        
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
        Vector3 CurrentPos = path.GetClosestPointToPath(rightHandT.position);
        Vector3 TargetPos = path.GetPointInPath(experimentalConfig.GetCurrentTarget());
        float CurrentGain = experimentalConfig.GetCurrentGain();


    }
   
}
