using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {

        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Person(string firstName, string lastName, int age, decimal salary)
             : this(firstName, lastName, age)
        {
            this.Salary = salary;
        }

        public string FirstName 
        { 
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = ValidateFirstName(value);
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = ValidateLastName(value);
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = ValidateAge(value);
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = ValidateSalary(value);
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal delimeter = 100;

            if (this.Age < 30)
            {
                delimeter = 200;
            }

            this.Salary += this.Salary * percentage / delimeter;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

        public string ValidateFirstName(string name)
        {
            if (name == null || name.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            return name;
        }

        public string ValidateLastName(string name)
        {
            if (name == null || name.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            return name;
        }

        public int ValidateAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            return age;
        }

        public decimal ValidateSalary(decimal salary)
        {
            if (salary < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }

            return salary;
        }
    }
}
