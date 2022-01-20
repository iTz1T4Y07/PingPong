using ClientCore;
using PingPong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientImplementations
{
    public class PersonInputGetter : IGetInput<Person>
    {
        public Person GetInput()
        {
            Console.WriteLine("Please enter person name");
            string name = Console.ReadLine();
            Console.WriteLine($"Please enter {name}'s age");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                return null;
            }
            return new Person(name, age);
        }
    }
}
