using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;

namespace Problem02
{
    class _02Start
    {
        static void Main()
        {
            string text = Console.ReadLine();

            MatchCollection nums = Regex.Matches(text, @"[0-9]");

            BigInteger multiplied = 1;

            for (int i = 0; i < nums.Count; i++)
            {
                multiplied *= BigInteger.Parse(nums[i].Value);
            }

            MatchCollection emojis = Regex.Matches(text, @"([\:\:]{2}|[\*\*]{2})([A-Z][a-z]{2,})\1");

            List<string> cools = new List<string>();

            for (int i = 0; i < emojis.Count; i++)
            {
                BigInteger emojiSum = 0;
                for (int j = 0; j < emojis[i].Groups[2].Length; j++)
                {
                    emojiSum += emojis[i].Groups[2].Value[j];
                }
                if (emojiSum >= multiplied)
                {
                    cools.Add(emojis[i].Value);
                }
            }
            Console.WriteLine($"Cool threshold: {multiplied}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (var emoji in cools)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
