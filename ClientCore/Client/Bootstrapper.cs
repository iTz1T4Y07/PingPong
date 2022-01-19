using ClientCore;
using ClientImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Bootstrapper
    {
        public void Run()
        {
            Console.WriteLine("===Client===");
            Console.WriteLine("Please enter the desired IP");
            IPAddress serverIp = IPAddress.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the desired port");
            int clientPort = int.Parse(Console.ReadLine());
            Client<string> client = new Client<string>(serverIp, clientPort, new StringInputGetter(), new StringDataConverter());
            client.Run();
        }
    }
}
