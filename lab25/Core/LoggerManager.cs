using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public class LoggerManager
{
    private static LoggerManager? instance;
    private ILogger? logger;

    private LoggerManager() { }

    public static LoggerManager Instance
    {
        get
        {
            instance ??= new LoggerManager();
            return instance;
        }
    }

    public void Initialize(LoggerFactory factory)
    {
        logger = factory.CreateLogger();
    }

    public void SetFactory(LoggerFactory factory)
    {
        logger = factory.CreateLogger();
    }

    public void Log(string message)
    {
        if (logger == null)
            throw new InvalidOperationException("LoggerManager не ініціалізований. Виклич Initialize().");

        logger.Log(message);
    }
}
