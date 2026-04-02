namespace Encode2It.Core;

public class Logger
{

    public string Name = "Log";

    public Logger(string name)
    {
        Directory.CreateDirectory("./Logs");
        Directory.CreateDirectory($"./Logs/{name}");
        Name = name;
    }

    private void LogTemplate(string type, string msg)
    {
        string message = $"[{type}] - {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} - {msg}";
        string path = $"./Logs/{Name}/{DateTime.Now.ToShortDateString()}";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(message);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(message);
            }
        }
    }

    public void Info(string msg)
    {
        LogTemplate("INFO", msg);
    }

    public void Warn(string msg)
    {
        LogTemplate("WARNING", msg);
    }
    public void Error(string msg)
    {
        LogTemplate("ERROR", msg);
    }
}