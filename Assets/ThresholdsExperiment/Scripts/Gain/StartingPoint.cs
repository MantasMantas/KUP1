using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    public VoidEvent StartAreaEvent;
    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObject = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

        if (parentObject.CompareTag("RightHand")) 
        {
            StartAreaEvent.raiseEvent();
            gameObject.SetActive(false);
        }
        else 
        {
            Debug.Log(other.tag);
        }

        
    }
}
