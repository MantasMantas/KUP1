using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Target Positions", menuName = "Scriptable Objects/Target/Target Positions")]
public class TargetPositions : ScriptableObject
{
    [Range(0f, 1f)]
    public float[] targetPositions;

    public float GetRandomTargetPosition() 
    {
        return targetPositions[Random.Range(0, targetPositions.Length)];
    }
}
