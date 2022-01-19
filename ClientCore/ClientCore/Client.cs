using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientCore
{
    public class Client<T>
    {
        private Socket _socket;

        IGetInput<T> _inputGetter;

        IDataConvert<T> _dataConverter;

        public Client(IPAddress ip, int port, IGetInput<T> inputGetter, IDataConvert<T> dataConverter)
        {
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(ip, port);

            _inputGetter = inputGetter;
            _dataConverter = dataConverter;
        }

        public void Run()
        {
            while (true)
            {
                T input = _inputGetter.GetInput();
                _socket.Send(_dataConverter.Convert(input));
                byte[] receivedData = new byte[1024];
                _socket.Receive(receivedData);
                Console.WriteLine(Encoding.ASCII.GetString(receivedData.Where(byteValue => byteValue != 0).ToArray()));
            }
        }
    }
}
