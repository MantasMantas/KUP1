using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentManager : MonoBehaviour
{

    public ExperimentConfiguration experimentConfiguration;
    public Flag inStartArea;
    public VoidEvent trialStart, trialEnd;
    public FloatEvent TimerStart;

    public float TimeOutDuration = 5f;

    public LogFile logFile;

    public Transform CursorPos;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            AudioClip audioClip = experimentConfiguration.GetVibration();
            float duration = experimentConfiguration.GetDuration();

            trialStart.raiseEvent();
            TimerStart.raiseEvent(duration);

            audioSource.clip = audioClip;
            audioSource.Play();

            logFile.WriteNewLine(audioClip.name + ": " + duration);
        }
        else
        {
            Debug.Log("Controller is not in the start area!");
        }
    }

    public void TimerExpired() 
    {
        audioSource.Stop();
        trialEnd.raiseEvent();
        logFile.WriteNewLine("Cursor position: " + CursorPos.position);
        //TimerStart.raiseEvent(TimeOutDuration);
    }

}
