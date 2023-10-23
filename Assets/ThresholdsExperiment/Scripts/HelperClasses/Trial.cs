using UnityEngine;

public class Trial
{
    private bool vibration;
    private float direction;
    private float gain;
    private int vibrationSetting;

    public Trial(bool vib, float dir, float g)
    {
        vibration = vib;
        direction = dir;
        gain = g;
        vibrationSetting = FindVibSetting();
    }

    public bool GetVib()
    {
        return vibration;
    }

    public float GetDir()
    {
        return direction;
    }

    public float GetG()
    {
        return gain;
    }

    public int GetVibrationSetting() 
    {
        return vibrationSetting;
    }

    private int FindVibSetting() 
    {
        if (!vibration) 
        {
            return -2;
        }
        else if(direction > 0.5f && gain > 1) //up left farther + gain
        {
            return 1;
        }
        else if (direction > 0.5f && gain < 1) //up left farther - gain
        {
            return -1;
        }
        else if (direction > 0.5f && gain == 1) //up left farther no gain
        {
            return 1;
        }
        else if (direction < 0.5f && gain > 1) //down right nearer + gain
        {
            return -1;
        }
        else if (direction < 0.5f && gain < 1) //down right nearer - gain
        {
            return 1;
        }
        else if (direction < 0.5f && gain == 1) //down right nearer no gain
        {
            return -1;
        }
        else 
        {
            Debug.LogWarning("Something wrong in the trial data!");
            return -2;
        }

    }
}
