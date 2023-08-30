using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class CSVTool
{
    public static void WriteLine(string path, string line)
    {
        TextWriter tw = new StreamWriter(path, true);
        tw.Write(line);
        tw.Close();
    }

    public static void WriteNewLine(string path, string line)
    {
        TextWriter tw = new StreamWriter(path, true);
        tw.WriteLine(line);
        tw.Close();
    }
}
