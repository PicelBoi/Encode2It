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

    private void LogTemplate(string type, string msg, ConsoleColor fgcolor, ConsoleColor bgcolor)
    {
        string message = $"[{type}] - {Name} - {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} - {msg}";
        string path = $"./Logs/{Name}/{DateTime.Now.ToString("MM-dd-yyyy")}.txt";
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
        Console.BackgroundColor = bgcolor;
        Console.ForegroundColor = fgcolor;
        Console.WriteLine(message);
    }

    public void Debug(string msg)
    {
        LogTemplate("DEBUG", msg, ConsoleColor.Gray, ConsoleColor.Black);
    }

    public void Info(string msg)
    {
        LogTemplate("INFO", msg, ConsoleColor.White, ConsoleColor.Black);
    }

    public void Warn(string msg)
    {
        LogTemplate("WARNING", msg, ConsoleColor.Yellow, ConsoleColor.Black);
    }
    public void Error(string msg)
    {
        LogTemplate("ERROR", msg, ConsoleColor.Black, ConsoleColor.Red);
    }
}