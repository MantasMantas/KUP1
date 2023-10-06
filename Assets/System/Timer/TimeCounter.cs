using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeCounter
{
    private bool isCounting;
    private float timeCount;

    public TimeCounter() { }
    public void SetTimeCount() 
    {
        timeCount = 0;
        isCounting = true;
    }

    public float GetTimeStamp() 
    {
        return timeCount;
    }

    public void StopTimeCount() 
    {
        isCounting = false;
    }

    public float StopAndGet() 
    {
        isCounting = false;
        return timeCount;
    }
    public void CounterUpdates() 
    {
        if (isCounting) 
        {
            timeCount += Time.deltaTime;
        }
    }

}
