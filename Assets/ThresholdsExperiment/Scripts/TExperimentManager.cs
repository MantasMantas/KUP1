using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExperimentManager : MonoBehaviour
{
    public TExperimentConfiguration experimentConfig;
    public FloatEvent TimerStart;
    public VoidEvent StartAreaFocus;
    
    // Start is called before the first frame update
    void Start()
    {
        StartAreaFocus.raiseEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAreaTrigger() 
    {
        
    }

    
}
