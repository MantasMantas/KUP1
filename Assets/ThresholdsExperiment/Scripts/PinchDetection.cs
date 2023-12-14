using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public Flag pinchFlag;
    public Transform posSocket;

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //GameObject parentObject = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

        if (other.tag == "RightHand") 
        {
            if (pinchFlag.GetFlag())
            {
                transform.position = posSocket.position;
            }
        }
        
    }
}
