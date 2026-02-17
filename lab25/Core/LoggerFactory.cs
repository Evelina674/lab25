using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public abstract class LoggerFactory
{
    public abstract ILogger CreateLogger();
}

