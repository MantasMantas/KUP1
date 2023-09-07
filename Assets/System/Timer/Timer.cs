using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeCount;
    private bool isCounting;
    private int totalFrames;
   

    // external dependencies
    public VoidEvent TimerFinished;


    // every frame run the timer if it is initiated otherwise check to see if it needs to count
    void Update()
    {
        CounterUpdates();
    }

    // method for initiating the timer, it is declared as a dynamic function that is able to take in input that is passed trough the event
    [SerializeField]
    public void SetFrameTimer(int seconds)
    {
        if (seconds > 0)
        {
            isCounting = true;
            timeCount = seconds;
        }
        else
        {
            Debug.LogWarning("The frame amount you inputed is invalid!");
        }
    }

    private void CounterUpdates()
    {

        if (isCounting)
        {
            if (timeCount == 0)
            {
                CounterStop();
            }

            timeCount =- Time.deltaTime;
            
        }
    }

    private void CounterStop()
    {
        isCounting = false;
        TimerFinished.raiseEvent();
        // Debug.Log("The frames have run out!");
        // Debug.Log("Total frames: " + totalFrames + "\n Total time: " + totalTime * 1000f + "ms");
    }
}
