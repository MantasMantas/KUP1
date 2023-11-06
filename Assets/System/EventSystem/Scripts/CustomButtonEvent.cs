using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButtonEvent : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent downEvent;

    public Material defaultMat;
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        
       downEvent?.Invoke();
        
    }

    private void OnTriggerExit(Collider other)
    {
        renderer.material = defaultMat;
    }
}
