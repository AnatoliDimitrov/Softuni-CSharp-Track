using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisementMessage
{
    class AdvertisementMessageStart
    {
        static void Main()
        {
            List<string> phrases = new List<string>() {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            List<string> events = new List<string>() {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            StringBuilder phrase = new StringBuilder();

            Random rand = new Random();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int index = rand.Next(0, phrases.Count);
                phrase.Append(phrases[index]);
                phrase.Append(" ");

                index = rand.Next(0, events.Count);
                phrase.Append(events[index]);
                phrase.Append(" ");

                index = rand.Next(0, authors.Count);
                phrase.Append(authors[index]);
                phrase.Append(" - ");

                index = rand.Next(0, cities.Count);
                phrase.Append(cities[index]);

                Console.WriteLine(phrase);
                phrase.Clear();
            }
        }
    }
}
