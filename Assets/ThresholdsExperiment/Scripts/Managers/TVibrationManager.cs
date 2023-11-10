using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVibrationManager : MonoBehaviour
{
    public TExperimentConfiguration experimentalConfig;

    private AudioSource audioSource;
    private float Gvalue;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVibrationConfig() 
    {
        int vibrationSetting = experimentalConfig.GetCurrentVibration();
        
        if(vibrationSetting == -2) 
        {
            audioSource.volume = 0;
            return;
        }

        audioSource.volume = experimentalConfig.GetGvalue();
        audioSource.panStereo = vibrationSetting;
    }
}
