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
        private TcpClient _client;

        IGetInput<T> _inputGetter;

        IDataConvert<T> _dataConverter;

        public Client(IPAddress ip, int port, IGetInput<T> inputGetter, IDataConvert<T> dataConverter)
        {
            _client = new TcpClient();
            _client.Connect(ip, port);

            _inputGetter = inputGetter;
            _dataConverter = dataConverter;
        }

        public void Run()
        {
            while (true)
            {
                T input = _inputGetter.GetInput();
                if (input != null)
                {
                    byte[] bytes = _dataConverter.Convert(input);
                    SendData(bytes);
                    byte[] receivedData = ReadData();
                    Console.WriteLine(Encoding.ASCII.GetString(receivedData.Where(byteValue => byteValue != 0).ToArray()));
                }
            }
        }

        private bool SendData(byte[] dataToSend)
        {
            _client.SendBufferSize = dataToSend.Length;
            NetworkStream stream = _client.GetStream();
            if (!(stream.CanWrite))
            {
                return false;
            }

            stream.Write(dataToSend, 0, dataToSend.Length);
            return true;
        }

        private byte[] ReadData()
        {
            NetworkStream stream = _client.GetStream();
            if (!stream.CanRead)
            {
                return null;
            }

            if (_client.ReceiveBufferSize <= 0)
            {
                _client.ReceiveBufferSize = 1024;
            }

            byte[] receivedData = new byte[_client.ReceiveBufferSize];
            stream.Read(receivedData, 0, _client.ReceiveBufferSize);
            return receivedData;
        }
    }
}
