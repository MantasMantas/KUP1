using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    private string header;
    public LogFile logFile;
    public TExperimentConfiguration experimentalConfig;
    public FloatVariable exposureTime;
   

    // Start is called before the first frame update
    void Start()
    {
        header = "trial number, target position, gain, vibration, exposure time, 2afc, embodiment";
        logFile.StartTheLog(header);

    }

    public void LogData() 
    {
        string lineToWrite = experimentalConfig.trialIndex + "," + experimentalConfig.GetCurrentTarget() + "," +
            experimentalConfig.GetCurrentGain() + "," + experimentalConfig.GetCurrentVibration() + "," +
            exposureTime.Get() + "," + experimentalConfig.GetTwoAfc() + "," + experimentalConfig.GetEmbodiment();
        
        logFile.WriteNewLine(lineToWrite);
    }
}
