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
    }
}
