using PingPong.Common;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerImplementations
{
    public class PersonObjectProcessor : IDataProcessor
    {
        public byte[] GetDataToReturn(byte[] receivedData)
        {
            string jsonString = Encoding.ASCII.GetString(receivedData);
            Person personReceived;
            try
            {
                personReceived = JsonSerializer.Deserialize<Person>(jsonString);
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Failed to deserialize person. {e}");
                return new byte[1] { 0 };
                //Change Console to log
            }

            Console.WriteLine($"Received new person! [{personReceived.ToString()}]");
            return receivedData;
        }
    }
}
