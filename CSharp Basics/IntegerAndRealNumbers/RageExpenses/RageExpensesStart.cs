namespace RageExpenses
{
    using System;
    class RageExpensesStart
    {
        static void Main()
        {
            int lostsCounter = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int headsetTrashes = 0;
            int mouseTrashes = 0;
            int keyboardTrashes = 0;
            int displayTrashes = 0;

            int keyboardCounter = 0;

            for (int i = 1; i <= lostsCounter; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrashes++;
                }
                if (i % 3 == 0)
                {
                    mouseTrashes++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrashes++;
                    keyboardCounter++;
                }
                if (keyboardCounter == 2)
                {
                    displayTrashes++;
                    keyboardCounter = 0;
                }
            }
            decimal totalExpences = (headsetTrashes * headsetPrice) + (mouseTrashes * mousePrice)
                    + (keyboardTrashes * keyboardPrice) + (displayTrashes * displayPrice);

            Console.WriteLine("Rage expenses: {0:0.00} lv.", totalExpences);
        }
    }
}
