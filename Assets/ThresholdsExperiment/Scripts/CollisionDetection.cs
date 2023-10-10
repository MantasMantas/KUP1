using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public MaterialsList materials;
    public VoidEvent TargetEvent, StartAreaEvent;
    public TExperimentConfiguration experimentConfig;

    private Renderer renderer;
    private bool counting;
    private float counter, threshold;
    private VoidEvent currentEvent;

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
        AssignMaterial(materials.GetDefault());
    }

    private void Update()
    {
        if (counting) 
        {
            if(counter >= threshold) 
            {
                counting = false;
                currentEvent.raiseEvent();
                counter = 0;
                return;
            }

            counter += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!counting) 
        {
            counting = true;
            if (this.name == "StartArea")
            {
                threshold = experimentConfig.startTouchingDuration;
                currentEvent = StartAreaEvent;
            }

            if (this.name == "Target")
            {
                threshold = experimentConfig.targetTouchDuration;
                currentEvent = TargetEvent;
            }

        }
       

        AssignMaterial(materials.GetTouching());
    }

    private void OnTriggerExit(Collider other)
    {
        counting = false;
        counter = 0;

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
