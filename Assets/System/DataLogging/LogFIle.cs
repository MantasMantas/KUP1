using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Log file", menuName = "LoggingSystem/New Log file")]
public class LogFIle : ScriptableObject
{
    private string directory = Path.Combine(Application.dataPath) + "/Reports";
    private string path;

    public string fileName;

    private void OnEnable()
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        path = directory + "/" + fileName + ".csv";
        TextWriter tw = new StreamWriter(path , false);
        tw.WriteLine("Start of the file");
        tw.Close();
    }

    public void WriteLine(string line)
    {
        TextWriter tw = new StreamWriter(path, true);
        tw.Write(line);
        tw.Close();
    }

    public void WriteNewLine(string line)
    {
        TextWriter tw = new StreamWriter(path, true);
        tw.WriteLine(line);
        tw.Close();
    }


}
