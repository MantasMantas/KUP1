using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private bool isCounting;
    private float timeCount;

    public FloatEvent TimeElapsed;
   

    // Update is called once per frame
    void Update()
    {
        CounterUpdates();
    }

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
    private void CounterUpdates() 
    {
        if (isCounting) 
        {
            timeCount += Time.deltaTime;
        }
    }

}
