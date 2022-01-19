using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerImplementations
{
    public class StringDataProcessor : IDataProcessor
    {
        public byte[] GetDataToReturn(byte[] receivedData)
        {            
            Console.WriteLine($"Received [{Encoding.ASCII.GetString(receivedData.Where(byteValue => byteValue != 0).ToArray())}]");
            return receivedData;
        }
    }
}
