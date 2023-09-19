using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStartArea : MonoBehaviour
{
    public Material defaultMat, selectedMat;
    public Flag inStartArea;
    private Renderer renderer;

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
        inStartArea.DisableFlag();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RightController") 
        {
            // do some things
            //Debug.Log("Controller entered");
            renderer.material = selectedMat;
            inStartArea.EnableFlag();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "RightController")
        {
            // do some things
            //Debug.Log("Controller exited");
            renderer.material = defaultMat;
            inStartArea.DisableFlag();
        }
    }
}
