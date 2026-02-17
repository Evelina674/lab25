using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public interface IDataProcessorStrategy
{
    string Process(string input);
    string Name { get; }
}

