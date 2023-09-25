using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public MaterialsList materials;
    public Flag inStartArea;
    public VoidEvent TargetEvent;

    private Renderer renderer;

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
        AssignMaterial(materials.GetDefault());
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(this.name == "StartArea") 
        {
            inStartArea.EnableFlag();
        }
        if(this.name == "Target") 
        {
            TargetEvent.raiseEvent();
        }

        AssignMaterial(materials.GetTouching());
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.name == "StartArea")
        {
            inStartArea.DisableFlag();
        }

        AssignMaterial(materials.GetDefault());
    }

    public void FocusOnMaterial() 
    {
        AssignMaterial(materials.GetFocusOn());
    }

    private void AssignMaterial(Material mat) 
    {
        if(renderer!= null) 
        {
            renderer.material = mat;
        }
        else 
        {
            Debug.LogWarning("The renderer was not assigned at object: " + this.name);
        }
    }
}
