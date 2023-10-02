using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{

    public LogFile logFile;

    private AudioSource audioSource;
    private float volumeValue, timeElapsed;
    private string Header = "Channel(-1 left|| 1 right), G(0-22 || 1-6.5 .25), Detected?, if true time in milis,";
    private bool wasDetected;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        logFile.StartTheLog(Header);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    public void PrintDropDown(int value) 
    {
        Debug.Log("Received value: " + value);
    }

    [SerializeField]
    public void SetVolume(int value) 
    {
        switch(value) 
        {
            case 0: volumeValue = 0.734f; // 6.5G
                break;
            case 1: volumeValue = 0.65f; // 6.25G
                break;
            case 2: volumeValue = 0.563f; // 6G
                break;
            case 3: volumeValue = 0.493f; // 5.75G
                break;
            case 4: volumeValue = 0.438f; // 5.5G
                break;
            case 5: volumeValue = 0.393f; // 5.25G
                break;
            case 6: volumeValue = 0.356f; // 5G
                break;
            case 7: volumeValue = 0.324f; // 4.75G
                break;
            case 8: volumeValue = 0.295f; // 4.5G
                break;
            case 9: volumeValue = 0.27f; // 4.25G
                break;
            case 10: volumeValue = 0.247f; // 4G
                break;
            case 11: volumeValue = 0.226f; // 3.75G
                break;
            case 12:volumeValue = 0.206f; // 3.5G
                break;
            case 13: volumeValue = 0.187f; // 3.25G
                break;
            case 14: volumeValue = 0.17f; // 3G
                break;
            case 15: volumeValue = 0.154f; // 2.75G
                break;
            case 16:volumeValue = 0.138f; // 2.5G
                break;
            case 17: volumeValue = 0.124f; // 2.25G
                break;
            case 18: volumeValue = 0.11f; // 2G
                break;
            case 19: volumeValue = 0.096f; // 1.75G
                break;
            case 20: volumeValue = 0.083f; // 1.5G
                break;
            case 21: volumeValue = 0.071f; // 1.25G
                break;
            case 22: volumeValue = 0.059f; // 1G
                break;
            default: volumeValue = 0f;
                break;
        }

        audioSource.volume = volumeValue;
    }

    public void LogTheAnswer() 
    {
        logFile.WriteNewLine(audioSource.panStereo.ToString() + "," + volumeValue + "," + wasDetected + "," + timeElapsed);
    }

}
