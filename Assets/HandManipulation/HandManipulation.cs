using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManipulation : MonoBehaviour
{
    public Transform hand, handVirtual, realCube, fakeCube, startPoint;
    public VoidEvent vibrationOn, vibrationOff;
    private Vector3 H0, T;
    private bool isStarted;

    void Start()
    {
        T = calculateDisplacement(fakeCube, realCube);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Hand position z: " + hand.position.z + " boundary position z: " + startPoint.position.z);
        if (hand.position.z > startPoint.position.z)
        {
            if (!isStarted)
            {
                isStarted = true;
                H0 = hand.position;
            }
            ApplyRetargeting();
            vibrationOn.raiseEvent();
        }
        else
        {
            vibrationOff.raiseEvent();
            isStarted = false;
        }
    }

    private Vector3 calculateDisplacement(Transform ob1, Transform ob2)
    {
        return ob1.position - ob2.position;
    }

    private void ApplyRetargeting()
    {
        float Ds = Vector3.Distance(hand.position, H0);
        float Dp = Vector3.Distance(hand.position, realCube.position);

        float a = Ds / (Ds + Dp);
        Vector3 W = a * T;

        handVirtual.position = new Vector3(hand.position.x + W.x, hand.position.y + W.y, hand.position.z + W.z);
    }
}
