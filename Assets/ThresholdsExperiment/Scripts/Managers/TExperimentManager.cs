using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExperimentManager : MonoBehaviour
{
    public TExperimentConfiguration experimentConfig;
    public FloatEvent TimerStart;
    public VoidEvent StartAreaPlacementProcedure;
    
    // Start is called before the first frame update
    void Start()
    {
        experimentConfig.RandomizedTrials();
        StartAreaPlacementProcedure.raiseEvent();
        experimentConfig.ResetIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAreaTrigger() 
    {
        
    }

    public void TargetEvent() 
    {
        TimerStart.raiseEvent(experimentConfig.restDuration);
    }

    public void IncreamentTrialIndex() 
    {
        int trialIndex = experimentConfig.IncreamentIndex();

        if(trialIndex == 0) 
        {
            //logic probably event to indicate the end of the block
        }

        // trialIndex variable used to record the trial data as the beggining of data stream
    }

    
}
