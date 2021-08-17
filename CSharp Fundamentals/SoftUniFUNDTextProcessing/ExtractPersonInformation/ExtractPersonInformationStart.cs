using System;

namespace ExtractPersonInformation
{
    class ExtractPersonInformationStart
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string personInfo = Console.ReadLine();

                int nameStart = personInfo.IndexOf('@') + 1;
                int nameEnd = personInfo.IndexOf('|');

                string name = personInfo.Substring(nameStart, personInfo.Length - (nameStart + (personInfo.Length - nameEnd)));

                int ageStart = personInfo.IndexOf('#') + 1;
                int ageEnd = personInfo.IndexOf('*');

                string age = personInfo.Substring(ageStart, personInfo.Length - (ageStart + (personInfo.Length - ageEnd)));

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
