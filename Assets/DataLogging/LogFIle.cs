using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Log file", menuName = "LoggingSystem/New Log file")]
public class LogFIle : ScriptableObject
{
    private string path = Path.Combine(Application.dataPath) + "/Reports";
    public string fileName;

    private void OnEnable()
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }


        TextWriter tw = new StreamWriter(path + "/" + fileName + ".csv" , false);
        tw.WriteLine("Start of the file");
        tw.Close();
    }




}
