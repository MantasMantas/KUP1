using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButtonEvent : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent downEvent;

    void OnTriggerEnter(Collider other)
    {
        GameObject parentObject = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        
        if (parentObject.tag == "LeftHand") 
        {
            downEvent?.Invoke();
        }
        
    }
}
