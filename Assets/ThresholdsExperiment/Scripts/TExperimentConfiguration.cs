using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.ParticleSystem;

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

    // gain stuff
    public float[] Gains;

    private Trial[] trials;
    private int trialIndex;
    
    private void OnValidate()
    {
        MakeGainsArray();
        MakeTrialsArray();
    }

    private void MakeGainsArray()
    {
        int arraySize = (int)((((maxGain - 1) / stepGain) + 1) * 2);
        Gains = new float[arraySize];

        int midllePoint = arraySize / 2;

        for (int i = 0; i < arraySize; i++)
        {
            if (i < midllePoint)
            {
                Gains[i] = (maxGain - (i * stepGain)) * -1;
            }
            if(i == midllePoint) 
            {
                Gains[i] = 1;
            }
            if (i > midllePoint)
            {
                Gains[i] = (1 + ((i - midllePoint) * stepGain));
            }

        }
    }

    private void MakeTrialsArray()
    {
        int arraySize = NumberOfRepetions * (Gains.Length * 2 * 2);  // 2 for vib states, 2 for directions
        trials = new Trial[arraySize];
        int trialIndex = 0;  // Use a separate index to keep track of the current trial being populated

        for (int rep = 0; rep < NumberOfRepetions; rep++)
        {
            for (int v = 0; v < 2; v++)  // Loop for vib states
            {
                bool vib = (v == 0);  // false for v=0, true for v=1

                for (int d = 0; d < 2; d++)  // Loop for directions
                {
                    float currentDir = (d == 0) ? targetCenterLeft : targetCenterRight;

                    for (int g = 0; g < Gains.Length; g++)  // Loop for gain values
                    {
                        float dir = Random.Range(currentDir - targetDisplacementMagnitude, currentDir + targetDisplacementMagnitude);
                        trials[trialIndex] = new Trial(vib, dir, Gains[g]);

                        trialIndex++;  // Increment the trial index for the next combination
                    }
                }
            }
        }
    }

    private void RandomizeTrialsArray()
    {
        Randomizer.ShuffleTrials(trials);
    }

    private void PrintTrialsArray() 
    {
        for(int i = 0; i < trials.Length; i++) 
        {
            Debug.Log(trials[i].GetVib() + " " + trials[i].GetDir() + " " + trials[i].GetG() + " vibration setting: " + trials[i].GetVibrationSetting());
        }
    }
    public int IncreamentIndex() 
    {
        if(trialIndex > trials.Length) 
        {
            return 0;
        }

        return ++trialIndex;
    }
    public void ResetIndex() 
    {
        trialIndex = 1;
    }
    public Trial GetCurrentConfig()
    {
        return trials[trialIndex];
    }
    public float GetCurrentGain() 
    {
        return trials[trialIndex].GetG();
    }

    public int GetCurrentVibration() 
    {
        return trials[trialIndex].GetVibrationSetting();
    }

    public float GetCurrentTarget() 
    {
        return trials[trialIndex].GetDir();
    }

    public void RandomizedTrials() 
    {
        RandomizeTrialsArray();
        PrintTrialsArray();
    }

    public void IncrementTrialIndex() 
    {
        if(trials.Length >= trialIndex) 
        {
            Debug.Log("All trials have been run!");
            // send some event to notify the system to stop the experimental block
            return;
        }
        
        trialIndex++;
    }
    public float GetGvalue() 
    {
        return GValuesUtil.GetGValue(gvalue);
    }
}


