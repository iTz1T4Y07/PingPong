using ClientCore;
using ClientImplementations;
using ServerCore;
using ServerImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class Bootstrapper
    {

        public void Start()
        {
            Console.WriteLine("===Server===");
            Console.WriteLine("Please enter the desired port");
            int serverPort = int.Parse(Console.ReadLine());
            IDataProcessor dataProcessor = new StringDataProcessor();
            IConnectionHandler<Socket> connectionHandler = new SocketConnectionHandler(dataProcessor);
            Server server = new Server(serverPort, connectionHandler);            
            Task serverTask = new Task(() =>server.Start());

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
