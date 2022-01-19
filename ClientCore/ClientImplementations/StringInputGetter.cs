using ClientCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientImplementations
{
    public class StringInputGetter : IGetInput<string>
    {
        public string GetInput()
        {
            Console.WriteLine("Please enter your message");
            return Console.ReadLine();
        }
    }
}
