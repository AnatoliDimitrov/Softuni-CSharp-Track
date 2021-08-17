using System;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (!CheckNumber(number))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            
            Console.WriteLine($"Dialing... {number}");
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
    }
}
