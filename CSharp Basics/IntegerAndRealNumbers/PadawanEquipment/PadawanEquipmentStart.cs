namespace PadawanEquipment
{
    using System;
    class PadawanEquipmentStart
    {
        static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            decimal lightSabrePrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());

            int sabresCount = (int)Math.Ceiling(studentsCount * 1.1);
            int freeBeltsCount = studentsCount / 6;
            int beltsCount = studentsCount - freeBeltsCount;

            decimal totalPrice = (sabresCount * lightSabrePrice) + (robePrice * studentsCount) + (beltsCount * beltPrice);
            
            if (totalPrice <= budget)
            {
                Console.WriteLine("The money is enough - it would cost {0:0.00}lv.", totalPrice);
            }
            else
            {
                Console.WriteLine("Ivan Cho will need {0:0.00}lv more.", totalPrice - budget);
            }
        }
    }
}
