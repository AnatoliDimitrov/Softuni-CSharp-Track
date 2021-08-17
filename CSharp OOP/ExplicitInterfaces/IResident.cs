﻿namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get;}

        public string Country { get;}

        public string GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
