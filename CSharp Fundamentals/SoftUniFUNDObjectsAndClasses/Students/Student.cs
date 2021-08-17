using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Student
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public float Grade { get; private set; }

        public Student(string firstName, string secondName, float grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}: {this.Grade:f2}";
        }
    }
}
