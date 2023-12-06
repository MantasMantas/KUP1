using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain : MonoBehaviour
{
    public float gain = 1.0f;
    public Transform realHand, virtualHand;
    private Vector3 originPoint;
    private bool isGain;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GainUpdate();
    }

    private void GainUpdate() 
    {
        if(isGain) 
        {
            virtualHand.position = GainWarp(realHand.position, originPoint, gain);
        }
    }

    private Vector3 GainWarp(Vector3 pr, Vector3 o, float g) 
    {
        Vector3 dr = pr - o; // Unwarped offset from origin
        Vector3 dv = g * dr; // Warped offset from origin
        Vector3 pv = o + dv; // Final warped position

        return pv;
    }

    public void StartGain() 
    {
        originPoint = realHand.position;
        isGain = true;
    }

    public void StopGain() 
    {
        isGain = false;
    } 
}
