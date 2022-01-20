using ClientCore;
using PingPong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientImplementations
{
    public class PersonDataConverter : IDataConvert<Person>
    {
        public byte[] Convert(Person dataToConvert)
        {
            string jsonString;
            try
            {
                jsonString = JsonSerializer.Serialize(dataToConvert);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine($"Couldn't serialize person object. {e}");
                //Change console to logger
                return new byte[] { 0 };
            }

            return Encoding.ASCII.GetBytes(jsonString);
        }
    }
}
