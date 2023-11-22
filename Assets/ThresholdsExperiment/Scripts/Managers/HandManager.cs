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

    // Movement delta stuff
    private Queue<float> positionBuffer = new Queue<float>();
    private int bufferSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBufer();
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
        float currentGain = experimentalConfig.GetCurrentGain();

        if(currentGain == 1 || !gainEnabled) 
        {
            return;
        }

        // Fetching all the necessary variables for calculation
        // float targetPoint = experimentalConfig.GetCurrentTarget();
        float currentPointOnPath = path.GetClosestCurveValue(righHandPos.position);

        if (positionBuffer.Count >= bufferSize)
        {
            positionBuffer.Dequeue();
        }

        positionBuffer.Enqueue(currentPointOnPath);

        float currentDelta = CalculateAverageMovementDelta();

        float deltaGain = currentDelta * currentGain;

        rightHand.transform.position = path.GetPointInPath(deltaGain);

        Debug.Log("Current point on path: " + currentPointOnPath + "Point on path with gain")


        /*float normalizedDistance = 0f;

        // calculating the normalized distance used for linear interpolation
        if(targetPoint > 0.5f) 
        {
            normalizedDistance = Mathf.InverseLerp(0.5f, targetPoint, currentPointOnPath);
        }
        else 
        {
            normalizedDistance = Mathf.InverseLerp(targetPoint, 0.5f, currentPointOnPath);
        }
        

        // calulating the gain based on current distance to target
        float AppliedGain = Mathf.Lerp(1, CurrentGain, normalizedDistance);
        Debug.Log("Applied gain: " + AppliedGain);
        float gainPointOnPath = AppliedGain * currentPointOnPath;
        Debug.Log("Current point on path: " + currentPointOnPath + "New point on parth: " + gainPointOnPath);

        // applying the gain to the hand
        Vector3 curveReference = path.GetPointInPath(gainPointOnPath);
        //rightHand.transform.position = new Vector3(rightHand.transform.position.x, curveReference.y, curveReference.z);
        rightHand.transform.position = new Vector3(curveReference.x, rightHand.transform.position.y, curveReference.z);
        //rightHand.transform.position = new Vector3(curveReference.x, curveReference.y, rightHand.transform.position.z);
        //rightHand.transform.rotation = path.GetRotationInPath(gainPointOnPath);*/

    }

    private void InitializeBufer() 
    {
        for (int i = 0; i < bufferSize; i++)
        {
            positionBuffer.Enqueue(path.GetClosestCurveValue(righHandPos.position));
        }
    }

    private float CalculateAverageMovementDelta() 
    {
        float SumOfDeltas = 0f;
        float previousPosition = positionBuffer.Peek();

        foreach(var position in positionBuffer) 
        {
            float delta = position - previousPosition;
            SumOfDeltas += delta;
            previousPosition = position;
        }

        return SumOfDeltas / (positionBuffer.Count - 1);
    }


}
