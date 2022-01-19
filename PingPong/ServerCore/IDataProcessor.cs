using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
    public interface IDataProcessor<T>
    {
        T GetDataToReturn(T receivedData);
    }
}
