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

    // filtering stuff
    private Queue<Vector3> positions = new Queue<Vector3>();
    public int bufferSize = 5;
    private Vector3 smoothedPosition;

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

        UpdatePosition(rightHand.transform.position);
        CheckMovement();
        

    }


    private void CheckMovement() 
    {
        if (Vector3.Distance(smoothedPosition, PreviousHandPosition) > movementThreshold)
        {

            if (!isMoving)
            {
                isMoving = true;
                HandMovementEvent.raiseEvent();
            }


            PreviousHandPosition = smoothedPosition;
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                HandStopEvent.raiseEvent();

            }
        }
    }
    private void UpdatePosition(Vector3 newPosition) 
    {
        if (positions.Count >= bufferSize)
        {
            positions.Dequeue();
        }

        positions.Enqueue(newPosition);

        smoothedPosition = Vector3.zero;
        foreach(var position in positions) 
        {
            smoothedPosition += position;
        }

        smoothedPosition /= positions.Count;
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
