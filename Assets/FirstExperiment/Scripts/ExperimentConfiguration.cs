using UnityEngine;

[CreateAssetMenu(fileName = "Experiment Configurations", menuName = "Scriptable Objects/Experiment/Configurations")]
public class ExperimentConfiguration : ScriptableObject
{
    public AudioClip[] vibrations;
    public float[] durations;

    private int RandNumGen() 
    {
        return Random.Range(0, vibrations.Length -1);
    }

    public AudioClip GetVibration() 
    {
        return vibrations[RandNumGen()];
    }

    public float GetDuration() 
    {
        return durations[RandNumGen()];
    }
}
