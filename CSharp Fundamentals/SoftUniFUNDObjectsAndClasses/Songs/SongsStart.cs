using System;
using System.Linq;
using System.Collections.Generic;

namespace Songs
{
    class SongsStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] song = Console.ReadLine().Split("_");

                songs.Add(new Song(song[0], song[1], song[2]));
            }

            string type = Console.ReadLine();

            if (type == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
                return;
            }
            List<string> result = songs
                .Where(s => s.TypeList == type)
                .Select(s => s.Name)
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

