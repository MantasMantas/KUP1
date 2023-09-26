using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExperimentManager : MonoBehaviour
{
    public FloatEvent TimerStart;
    public float Duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAreaTrigger() 
    {
        TimerStart.raiseEvent(Duration);
    }

    
}
