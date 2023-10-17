using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HandManager : MonoBehaviour
{
    public OVRHand rightHand;
    public float movementThreshold = 0.05f;

    public VoidEvent HandMovementEvent, HandStopEvent;

    private Vector3 CurrentHandPosition, PreviousHandPosition;
    private bool isMoving, isVibrationEnabled;
    // Start is called before the first frame update
    void Start()
    {
        isVibrationEnabled = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVibrationEnabled) 
        {
            return;
        }

        CurrentHandPosition = rightHand.transform.position;

        if(Vector3.Distance(CurrentHandPosition, PreviousHandPosition) > movementThreshold) 
        {

            if (!isMoving) 
            {
                isMoving = true;
                HandMovementEvent.raiseEvent();
            }
            

            PreviousHandPosition = CurrentHandPosition;
        }
        else 
        {
          if(isMoving) 
          {
            isMoving = false;
            HandStopEvent.raiseEvent();
                
          }
        }

    }

    public void EnableVibration() 
    {
        isVibrationEnabled = true;
    }

    public void DisableVibration() 
    {
        isVibrationEnabled = false;
    }

   
}
