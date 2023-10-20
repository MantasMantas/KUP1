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

    public float minGain = -1.5f ,maxGain = 1.5f, stepGain = 0.1f;
    public Gvalues gvalue;

    // gain stuff
    public float[] Gains;

    private Trial[] trials;
    private int trialIndex;
    
    private void OnValidate()
    {
        MakeGainsArray();
        MakeTrialsArray();
        //Trial trial = new Trial(true, 0.8f, 1f);

        //Debug.Log("vibration: " + trial.GetVib() + " direction: " + trial.GetDir() + " gain:" + trial.GetG());
        //Debug.Log(GValuesUtil.GetGValue(gvalue));
    }

    private void MakeGainsArray()
    {
        int arraySize = (int)((((maxGain - minGain) / stepGain) + 1) * 2);
        Gains = new float[arraySize];

        int midllePoint = arraySize / 2;

        for (int i = 0; i < arraySize; i++)
        {
            float value = 1 + (i * stepGain);
            if (i <= midllePoint)
            {
                Gains[i] = value;
            }
            if (i > midllePoint)
            {
                Gains[i] = (maxGain - value) + -1;
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

                        Debug.Log(trials[trialIndex].GetVib() + " " + trials[trialIndex].GetDir() + " " + trials[trialIndex].GetG());

                        trialIndex++;  // Increment the trial index for the next combination
                    }
                }
            }
        }
    }





    private void RandomizeTrialsArray()
    {
        Randomizer.Shuffle(trials);
    }
    public Trial GetCurrentConfig()
    {
        return trials[trialIndex];
    }
}


