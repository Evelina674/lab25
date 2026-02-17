using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab25.Core
{
    public class DataPublisher
    {
        public delegate void DataProcessedHandler(object? sender, string processedData);
        public event DataProcessedHandler? DataProcessed;

        public void PublishDataProcessed(string processedData)
        {
            DataProcessed?.Invoke(this, processedData);
        }
    }
}


