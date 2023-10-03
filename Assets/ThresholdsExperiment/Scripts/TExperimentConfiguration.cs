using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "T experiment config", menuName = "Scriptable Objects/Experiment/T experiment config")]
public class TExperimentConfiguration : ScriptableObject
{
    public float startTouchingDuration, targetTouchDuration, restDuration;
    public float[] targetPositions = { 1f, .8f, 0.6f, 0.4f, 0.2f, 0f };
    public float[] gains = { 2f, 1.75f, 1.5f, 1.25f, 1f, -1.25f, -1.5f, -1.75f, -2f };

    public float Gvalue = 0.734f;


}
