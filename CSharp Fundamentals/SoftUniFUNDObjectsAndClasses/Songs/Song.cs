using System;
using System.Collections.Generic;
using System.Text;

namespace Songs
{
    public class Song
    {
        public string TypeList { get; private set; }

        public string Name { get; private set; }

        public string Duration { get; private set; }

        public Song(string typeList, string name, string duration)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Duration = duration;
        }
    }
}
