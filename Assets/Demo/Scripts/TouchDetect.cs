using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour
{
    public VoidEvent startTouched;
    public StringEvent targetTouched;

    private void OnTriggerEnter(Collider other)
    {
        if(name == "StartArea") 
        {
            startTouched.raiseEvent(); 
        }
        else 
        {
            targetTouched.raiseEvent(name);
        }
    }
}
