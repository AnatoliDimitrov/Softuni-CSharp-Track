using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ERR_MSG = "Invalid input!";

        private string name;

        private int age;

        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string  Name
        {
            get { return this.name; }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ERR_MSG);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ERR_MSG);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ERR_MSG);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.Append($"{this.ProduceSound()}");

            return result.ToString().Trim();
        }
    }
}
