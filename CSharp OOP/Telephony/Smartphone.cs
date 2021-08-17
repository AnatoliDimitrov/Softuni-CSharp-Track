using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            if (!CheckNumber(number))
            {
                throw new InvalidOperationException("Invalid number!"); 
            }

            System.Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string site)
        {
            if (!CheckSite(site))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            System.Console.WriteLine($"Browsing: {site}!");
        }

        public bool CheckNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckSite(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
