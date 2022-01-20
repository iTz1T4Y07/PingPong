using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Common
{
    [Serializable]
    public class Person
    {
        private string _name;

        private int _age;

        public string Name { get => _name; }

        public int Age { get => _age; }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_name} is {_age} years old.";
        }
    }
}
