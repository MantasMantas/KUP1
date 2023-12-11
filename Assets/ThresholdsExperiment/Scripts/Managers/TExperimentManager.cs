using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExperimentManager : MonoBehaviour
{
    public TExperimentConfiguration experimentConfig;
    public FloatEvent TimerStart;
    public VoidEvent StartAreaPlacementProcedure;
    public BoolEvent RealHandVis, PacerVis;
    
    // Start is called before the first frame update
    void Start()
    {
        experimentConfig.RandomizedTrials();
        StartAreaPlacementProcedure.raiseEvent();
        experimentConfig.ResetIndex();

        RealHandVis.raiseEvent(experimentConfig.RealHand);
        PacerVis.raiseEvent(experimentConfig.Pacer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAreaTrigger() 
    {
        
    }

    public void StartRestCounter() 
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

    [SerializeField]
    public void Set2AFC(string value) 
    {
        experimentConfig.SetTwoAfc(value);
    }

    [SerializeField]
    public void SetEmbodiment(string value) 
    {
        experimentConfig.SetEmbodiment(value);  
    }

    
}
