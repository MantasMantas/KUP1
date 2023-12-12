using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public float maxGain = 1.5f, stepSize = 0.1f;
    public Gvalues gvalue;

    // gain stuff
    public float[] Gains;

    private Trial[] trials, practiceTrials;

    [HideInInspector]
    public int trialIndex;

    private string twoAFC, embodiment;

    public bool RealHand, PracticeTrials;

    public VoidEvent practiceOver, trialsEnd;
    
    private void OnValidate()
    {
        MakeGainsArray();
        MakeTrialsArray();
    }

    private void MakeGainsArray()
    {
        float maxValue = maxGain;
        float minValue = 2 - maxGain;

        int arraySize = (int)Math.Ceiling((maxValue - minValue) / stepSize) + 1;

        Gains = new float[arraySize];

        for(int i = 0; i < arraySize; i++) 
        {
            Gains[i] = minValue + (stepSize * i);
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
                        float dir = UnityEngine.Random.Range(currentDir - targetDisplacementMagnitude, currentDir + targetDisplacementMagnitude);
                        trials[trialIndex] = new Trial(vib, dir, Gains[g]);

                        trialIndex++;  // Increment the trial index for the next combination
                    }
                }
            }
        }

        if (PracticeTrials) 
        {
            practiceTrials = new Trial[8];

            practiceTrials[0] = new Trial(true, 0.2f, 1.5f);
            practiceTrials[1] = new Trial(false, 0.2f, 1.5f);
            practiceTrials[2] = new Trial(true, 0.2f, 0.5f);
            practiceTrials[3] = new Trial(false, 0.2f, 0.5f);
            practiceTrials[4] = new Trial(true, 0.8f, 1.5f);
            practiceTrials[5] = new Trial(false, 0.8f, 1.5f);
            practiceTrials[6] = new Trial(true, 0.8f, 0.5f);
            practiceTrials[7] = new Trial(false, 0.8f, 0.5f);
        }
    }

    private void RandomizeTrialsArray()
    {
        Randomizer.ShuffleTrials(trials);

        if (PracticeTrials) 
        {
            trials = practiceTrials.Concat(trials).ToArray();
        }
    }

    private void PrintTrialsArray() 
    {
        for(int i = 0; i < trials.Length; i++) 
        {
            Debug.Log(trials[i].GetVib() + " " + trials[i].GetDir() + " " + trials[i].GetG() + " vibration setting: " + trials[i].GetVibrationSetting());
        }
    }
    public void ResetIndex() 
    {
        trialIndex = 0;
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

    public float GetGvalue() 
    {
        return GValuesUtil.GetGValue(gvalue);
    }

    public void SetTwoAfc(string value) 
    {
        twoAFC = value;
    }

    public string GetTwoAfc() 
    {
        return twoAFC;
    }

    public void SetEmbodiment(string value) 
    {
        embodiment = value;
    }

    public string GetEmbodiment() 
    {
        return embodiment;
    }

    public void IncrementTrialIndex() 
    {
        trialIndex++;

        if(trialIndex == 8) 
        {
            practiceOver.raiseEvent();
        }

        if(trialIndex > trials.Length) 
        {
            trialsEnd.raiseEvent();
        }
    }
}


