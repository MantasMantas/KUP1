using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentManager : MonoBehaviour
{

    public ExperimentConfiguration experimentConfiguration;
    public Flag inStartArea;
    public VoidEvent trialStart;
    public FloatEvent TimerStart;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerPress()
    {
        // here goes the trigger press logic
        Debug.Log("Trigger was pressed!!!");
        if (inStartArea.GetFlag())
        {
            trialStart.raiseEvent();
            audioSource.clip = experimentConfiguration.GetVibration();

            TimerStart.raiseEvent(experimentConfiguration.GetDuration());
            audioSource.Play();
        }
        else
        {
            Debug.Log("Controller is not in the start area!");
        }
    }

    public void TimerExpired() 
    {
        audioSource.Stop();
    }

}
