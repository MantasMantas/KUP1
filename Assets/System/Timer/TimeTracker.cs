using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public FloatVariable elapsedTime;
    private float timeCount;
    private bool isCounting;

    // every frame run the timer if it is initiated otherwise check to see if it needs to count
    void Update()
    {
        if (isCounting) 
        {
            CounterUpdates();
        }
    }

    public void StartTimeTracker()
    {
        isCounting = true;
        timeCount = 0f;
    }

    private void CounterUpdates()
    {
        timeCount += Time.deltaTime;
    }

    public void StopTimeTracker()
    {
        isCounting = false;
        elapsedTime.Set(timeCount);
    }

}
