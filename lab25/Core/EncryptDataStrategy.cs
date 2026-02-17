using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab25.Core;

public class EncryptDataStrategy : IDataProcessorStrategy
{
    public string Name => "EncryptDataStrategy (Base64)";

    public string Process(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(bytes);
    }
}
