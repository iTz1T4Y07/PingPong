using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerImplementations
{
    public class TcpListenerConnectionHandler : IConnectionHandler<TcpClient>
    {
        private IDataProcessor _dataProcessor;

        public TcpListenerConnectionHandler(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public Task HandleNewConnection(TcpClient clientSocket)
        {
            throw new NotImplementedException();
        }
    }
}
