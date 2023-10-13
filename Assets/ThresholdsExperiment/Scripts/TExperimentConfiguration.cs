using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "T experiment config", menuName = "Scriptable Objects/Experiment/T experiment config")]
public class TExperimentConfiguration : ScriptableObject
{
    public PathShapes pathShapes;
    public int NumberOfRepetions = 2;

    public float startTouchingDuration, targetTouchDuration, restDuration;

    public float targetCenterLeft, targetCenterRight;
    public float targetDisplacementMagnitude;

    public float maxGain = 1.5f, stepGain = 0.1f;

    public Gvalues gvalue;

    private float[] Gains;
    
    private void OnValidate()
    {
        MakeGainsArray();

        Trial trial = new Trial(true, 0.8f, 1f);

        Debug.Log("vibration: " + trial.GetVib() + " direction: " + trial.GetDir() + " gain:" + trial.GetG());
        Debug.Log(GValuesUtil.GetGValue(gvalue));
    }

    
    private void MakeGainsArray()
    {
        int arraySize = (int)((((maxGain - 1) / stepGain) + 1) * 2);
        Gains = new float[arraySize];
        //Debug.Log(arraySize);

        int midllePoint = arraySize / 2;

        for (int i = 0; i < arraySize; i++)
        {
            float value = 1 + (i * stepGain);
            if(i <= midllePoint) 
            {
                Gains[i] = value;
            }
            if(i > midllePoint) 
            {
                Gains[i] = (maxGain - value) + -1;
            }
            
        }

    }

}


