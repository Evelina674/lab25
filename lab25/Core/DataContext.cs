using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public class DataContext
{
    private IDataProcessorStrategy strategy;

    public DataContext(IDataProcessorStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IDataProcessorStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public string ProcessData(string input)
    {
        return strategy.Process(input);
    }

    public string CurrentStrategyName => strategy.Name;
}

