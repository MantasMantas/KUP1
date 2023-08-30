using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReceiver : MonoBehaviour
{

    [SerializeField]
    public void PrintReceivedValue(Vector2 value) 
    {
        Debug.Log(value);
    }

    public void PrintReceivedPress() 
    {
        Debug.Log("Press was activated!");
    }

    private void Start()
    {
       
    }
}
