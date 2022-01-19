﻿using ClientCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientImplementations
{
    public class StringDataConverter : IDataConvert<string>
    {
        public byte[] Convert(string dataToConvert)
        {
            return Encoding.ASCII.GetBytes(dataToConvert);
        }
    }
}
