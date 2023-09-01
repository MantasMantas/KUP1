using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public GameObject StartArea, Target1;
    public Material defaultMat, highlightMat, touchedMat;

    bool trialStarted;

    // Start is called before the first frame update
    void Start()
    {
        StartTrial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTrial() 
    {
        StartArea.GetComponent<Renderer>().material = highlightMat;
        trialStarted = true;
    }

    [SerializeField]
    public void TargetTouched(string value) 
    {

    }

    public void StartTouched() 
    {
        StartArea.GetComponent<Renderer>().material = touchedMat;
    }
}
