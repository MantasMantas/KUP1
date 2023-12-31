using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Log file", menuName = "LoggingSystem/New Log file")]
public class LogFile : ScriptableObject
{
    private string directory = Path.Combine(Application.dataPath) + "/Reports";
    private string path;

    public string fileName;

    public int fileNumber = 1;

    public void StartTheLog(string Header) 
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        path = directory + "/" + fileName + fileNumber + ".csv";
        TextWriter tw = new StreamWriter(path, false);
        tw.WriteLine(Header);
        tw.Close();

        fileNumber++;
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
