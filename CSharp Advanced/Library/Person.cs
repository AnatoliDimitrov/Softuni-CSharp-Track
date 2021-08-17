using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Town = "";
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            if (this.Name.CompareTo(other.Name) == -1)
            {
                return -1;
            }
            else if (this.Name.CompareTo(other.Name) == 1)
            {
                return 1;
            }
            else
            {
                if (this.Age.CompareTo(other.Age) == -1)
                {
                    return -1;
                }
                else if (this.Age.CompareTo(other.Age) == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class PersonComparer : IEqualityComparer<Person>
    {
        //public int Compare([AllowNull] Person x, [AllowNull] Person y)
        //{
        //    if (x.Name.CompareTo(y.Name) == -1)
        //    {
        //        return -1;
        //    }
        //    else if (x.Name.CompareTo(y.Name) == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        if (x.Age.CompareTo(y.Age) == -1)
        //        {
        //            return -1;
        //        }
        //        else if (x.Age.CompareTo(y.Age) == 1)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}

        public bool Equals([AllowNull] Person x, [AllowNull] Person y)
        {
            if (x.CompareTo(y) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            throw new NotImplementedException();
        }
    }
}


