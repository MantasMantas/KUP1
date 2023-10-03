using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeCount;
    private bool isCounting;
   
    // external dependencies
    public VoidEvent TimerFinished;


    // every frame run the timer if it is initiated otherwise check to see if it needs to count
    void Update()
    {
        CounterUpdates();
    }

    // method for initiating the timer, it is declared as a dynamic function that is able to take in input that is passed trough the event
    [SerializeField]
    public void SetTimer(float seconds)
    {
        if (seconds > 0)
        {
            isCounting = true;
            timeCount = seconds;

            //Debug.Log("Timer started with: " + seconds + " Seconds");
        }
        else
        {
            Debug.LogWarning("The amount you inputed is invalid!");
        }
    }

    private void CounterUpdates()
    {

        if (isCounting)
        {
            if (timeCount <= 0)
            {
                CounterStop();
            }

            timeCount -= Time.deltaTime;
            
        }

    }

    private void CounterStop()
    {
        isCounting = false;
        TimerFinished.raiseEvent();
    }
}
