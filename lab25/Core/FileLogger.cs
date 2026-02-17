using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public class FileLogger : ILogger
{
    private string path = "log.txt";

    public void Log(string message)
    {
        File.AppendAllText(path, $"[File] {message}\n");
    }
}

