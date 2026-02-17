using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core;

public class ProcessingLoggerObserver
{
    public void Subscribe(DataPublisher publisher)
    {
        publisher.DataProcessed += OnDataProcessed;
    }

    private void OnDataProcessed(object? sender, string processedData)
    {
        LoggerManager.Instance.Log($"Observer: отримав оброблені дані -> {processedData}");
    }
}
