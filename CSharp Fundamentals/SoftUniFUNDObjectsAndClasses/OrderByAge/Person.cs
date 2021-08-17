using System;
using System.Collections.Generic;
using System.Text;

namespace OrderByAge
{
    public class Person
    {
        public string Name { get; private set; }

        public string ID { get; private set; }

        public int Age { get; private set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
