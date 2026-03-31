using Microsoft.Extensions.Logging;

namespace Encode2It.Core;

public class Log
{
    private ILoggerFactory Factory = LoggerFactory.Create(builder => builder.AddConsole());

    public ILogger? logger;

    public Log(string name)
    {
        logger = Factory.CreateLogger("Encode2It - " + name);
    }

    public void Info(string msg)
    {
        if (logger != null)
        {
            logger.LogInformation(msg);
        }
    }

    public void Warn(string msg)
    {
        if (logger != null)
        {
            logger.LogWarning(msg);
        }
    }
    public void Error(string msg)
    {
        if (logger != null)
        {
            logger.LogError(msg);
        }
    }
}