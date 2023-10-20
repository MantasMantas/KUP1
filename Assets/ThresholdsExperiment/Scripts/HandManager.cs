using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HandManager : MonoBehaviour
{
    public OVRHand rightHand;
    public float distanceThreshold;
    public TExperimentConfiguration experimentalConfig;
    public VoidEvent HandMovementEvent;

    private Vector3 StartingHandPosition, CurrentHandPosition;
    private bool isVibrationStarted, isVibrationEnabled;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVibrationEnabled || isVibrationStarted)

        {
            return;
        }


        if(Vector3.Distance(StartingHandPosition, CurrentHandPosition) >= distanceThreshold) 
        {
            isVibrationStarted = true;
            HandMovementEvent.raiseEvent();
        }
        else 
        {
            CurrentHandPosition = rightHand.transform.position;
        }
        

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

   
}
