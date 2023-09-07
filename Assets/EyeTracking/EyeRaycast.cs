using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRaycast : MonoBehaviour
{
    public LayerMask layerMask;
    public Material seenMaterial, defaultMaterial;

    public GameObject Cube, Sphere, Cylinder, Capsule;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.forward, Color.red);
        RaycastHit hit;

        Vector3 RaycastDirection = transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(transform.position, RaycastDirection, out hit, Mathf.Infinity, layerMask)) 
        {
            Debug.Log(hit.collider.name);
            hit.collider.GetComponent<Renderer>().material= seenMaterial;
           
        }
        else 
        {
            ResetMaterials();
        }

        
    }

    private void ResetMaterials() 
    {
        Cube.GetComponent<Renderer>().material= defaultMaterial;
        Sphere.GetComponent<Renderer>().material = defaultMaterial;
        Cylinder.GetComponent<Renderer>().material = defaultMaterial;
        Capsule.GetComponent<Renderer>().material = defaultMaterial;
    }


}
