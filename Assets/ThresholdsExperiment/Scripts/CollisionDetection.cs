using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public MaterialsList materials;
    public VoidEvent EventToCall;
    public TExperimentConfiguration experimentConfig;

    public Flag pinchFlag;

    private Renderer renderer;
    private bool counting;
    private float counter, threshold;

    private void OnEnable()
    {
        renderer = GetComponent<Renderer>();
        AssignMaterial(materials.GetDefault());

        if(this.name == "StartArea") 
        {
            threshold = experimentConfig.startTouchingDuration;
        }
        if(this.name == "Target") 
        {
            threshold = experimentConfig.targetTouchDuration;
        }
    }

    private void Update()
    {
        if (counting) 
        {
            if(counter >= threshold) 
            {
                counting = false;
                EventToCall.raiseEvent();
                counter = 0;
                return;
            }

            counter += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject parentObject = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
  
        if(parentObject.tag != "RightHand") { return; }
        if (!counting) 
        {
            counting = true;

        }
       
        AssignMaterial(materials.GetTouching());
    }

    private void OnTriggerExit(Collider other)
    {
        if (counting) 
        {
            counting = false;
            counter = 0;
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

   /* private void OnTriggerStay(Collider other)
    {
        if(this.name == "StartArea") 
        {
            if (pinchFlag.GetFlag())
            {
                transform.position = other.transform.position;

            }
        }
        
    }*/
}
