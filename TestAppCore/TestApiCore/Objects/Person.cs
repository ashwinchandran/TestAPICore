using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiCore.Objects
{
    public class Person
    {
        public string Name  { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        public Person()
        {
            Name = "Ashwin";
            Age = 10;
            Id = 1;
        }
    }
}
