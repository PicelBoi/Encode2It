namespace Encode2It.Core;

public class Logger
{

    public string Name = "Log";

    public Logger(string name)
    {
        name = "Encode2It - " + name;
    }

    private static void LogTemplate(string type, string msg)
    {
        Console.WriteLine($"[{type}] - {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} - {msg}");
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