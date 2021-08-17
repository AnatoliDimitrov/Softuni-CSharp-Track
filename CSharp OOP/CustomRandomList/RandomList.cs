using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {

        private Random rand;

        public RandomList()
        {
            rand = new Random();
        }

        public string RandomString()
        {
            int random = this.rand.Next(0, this.Count);

            string str = this[random];

            this.RemoveAt(random);

            return str;
        }
    }
}
