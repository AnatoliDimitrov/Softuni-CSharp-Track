namespace EnglishNameOfTheLastDigit
{
    using System;
    class EnglishNameOfTheLastDigitStart
    {
        static void Main()
        {
            string num = Console.ReadLine();
            int last = int.Parse(num[num.Length - 1].ToString());

            string englishName = "";

            switch (last)
            {
                case 0:
                    englishName = "zero";
                    break;
                case 1:
                    englishName = "one";
                    break;
                case 2:
                    englishName = "two";
                    break;
                case 3:
                    englishName = "three";
                    break;
                case 4:
                    englishName = "four";
                    break;
                case 5:
                    englishName = "five";
                    break;
                case 6:
                    englishName = "six";
                    break;
                case 7:
                    englishName = "seven";
                    break;
                case 8:
                    englishName = "eight";
                    break;
                default:
                    englishName = "nine";
                    break;
            }

            Console.WriteLine(englishName);
        }
    }
}
