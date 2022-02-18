using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlphaLibrary
{
    public class JsonCommon
    {
        public JsonCommon() { }
        //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0
        public bool SaveJson<T>(string fileName, T data)
        {
            using FileStream createStream = File.Create(fileName);
             JsonSerializer.Serialize(createStream, data);
             createStream.Dispose();
            return false;
        }
    }
}
