using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace lab25.Core;

public class CompressDataStrategy : IDataProcessorStrategy
{
    public string Name => "CompressDataStrategy (GZip+Base64)";

    public string Process(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);

        using var output = new MemoryStream();
        using (var gzip = new GZipStream(output, CompressionLevel.SmallestSize, leaveOpen: true))
        {
            gzip.Write(inputBytes, 0, inputBytes.Length);
        }

        return Convert.ToBase64String(output.ToArray());
    }
}

