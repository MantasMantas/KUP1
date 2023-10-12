using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "T experiment config", menuName = "Scriptable Objects/Experiment/T experiment config")]
public class TExperimentConfiguration : ScriptableObject
{
    public PathShapes pathShapes;
    public int NumberOfTrials = 10;

    public float startTouchingDuration, targetTouchDuration, restDuration;

    public float[] targetPositions = { 1f, .8f, 0.6f, 0.4f, 0.2f, 0f };
    public float[] gains = { 2f, 1.75f, 1.5f, 1.25f, 1f, -1.25f, -1.5f, -1.75f, -2f };

    public Gvalues gvalue;


    public float GetGvalue() 
    {
        float volumeValue;
        switch (gvalue)
        {
            case Gvalues.G6n5:
                volumeValue = 0.734f; // 6.5G
                break;
            case Gvalues.G6n25:
                volumeValue = 0.65f; // 6.25G
                break;
            case Gvalues.G6:
                volumeValue = 0.563f; // 6G
                break;
            case Gvalues.G5n75:
                volumeValue = 0.493f; // 5.75G
                break;
            case Gvalues.G5n5:
                volumeValue = 0.438f; // 5.5G
                break;
            case Gvalues.G5n25:
                volumeValue = 0.393f; // 5.25G
                break;
            case Gvalues.G5:
                volumeValue = 0.356f; // 5G
                break;
            case Gvalues.G4n75:
                volumeValue = 0.324f; // 4.75G
                break;
            case Gvalues.G4n5:
                volumeValue = 0.295f; // 4.5G
                break;
            case Gvalues.G4n25:
                volumeValue = 0.27f; // 4.25G
                break;
            case Gvalues.G4:
                volumeValue = 0.247f; // 4G
                break;
            case Gvalues.G3n75:
                volumeValue = 0.226f; // 3.75G
                break;
            case Gvalues.G3n5:
                volumeValue = 0.206f; // 3.5G
                break;
            case Gvalues.G3n25:
                volumeValue = 0.187f; // 3.25G
                break;
            case Gvalues.G3:
                volumeValue = 0.17f; // 3G
                break;
            case Gvalues.G2n75:
                volumeValue = 0.154f; // 2.75G
                break;
            case Gvalues.G2n5:
                volumeValue = 0.138f; // 2.5G
                break;
            case Gvalues.G2n25:
                volumeValue = 0.124f; // 2.25G
                break;
            case Gvalues.G2:
                volumeValue = 0.11f; // 2G
                break;
            case Gvalues.G1n75:
                volumeValue = 0.096f; // 1.75G
                break;
            case Gvalues.G1n5:
                volumeValue = 0.083f; // 1.5G
                break;
            case Gvalues.G1n25:
                volumeValue = 0.071f; // 1.25G
                break;
            case Gvalues.G1:
                volumeValue = 0.059f; // 1G
                break;
            case Gvalues.G0:
                volumeValue = 0f; // 0G
                break;
            default:
                volumeValue = 0f;
                break;
        }

        return volumeValue;
    }

}

public enum Gvalues 
{
   G0,
   G6n5,
   G6n25,
   G6,
   G5n75,
   G5n5,
   G5n25,
   G5,
   G4n75,
   G4n5,
   G4n25,
   G4,
   G3n75,
   G3n5,
   G3n25,
   G3,
   G2n75,
   G2n5,
   G2n25,
   G2,
   G1n75,
   G1n5,
   G1n25,
   G1
}

public enum PathShapes
{
    Horizontal,
    Vertical,
    Reaching
}