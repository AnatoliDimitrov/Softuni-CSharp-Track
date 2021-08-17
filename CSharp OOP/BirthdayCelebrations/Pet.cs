using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IPet, IBirthable
    {
        public Pet(string name,  string date)
        {
            this.Name = name;
            this.Birthdate = date;
        }

        public string Birthdate { get; private set; }
        public string Name { get; private set; }
    }
}
