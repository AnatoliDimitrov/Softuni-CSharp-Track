namespace Crossroads
{
    using System;
    using System.Collections.Generic;

    class CrossroadsStart
    {
        static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int passed = 0;

            Queue<string> carsQueue = new Queue<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    carsQueue.Enqueue(input);
                }
                else
                {

                    int currentGreenLight = greenLightDuration;
                    int currentFreeWindow = freeWindow;

                    while (currentGreenLight > 0 )
                    {

                        if (carsQueue.Count == 0)
                        {
                            break;
                        }

                        string currentCar = carsQueue.Peek();
                        int currentCarLength = currentCar.Length;

                        if (currentCarLength <= currentGreenLight)
                        {
                            carsQueue.Dequeue();

                            passed++;

                            currentGreenLight -= currentCarLength;
                        }
                        else
                        {
                            int wholeTime = currentGreenLight + currentFreeWindow;

                            if (currentCarLength <= wholeTime)
                            {
                                carsQueue.Dequeue();

                                passed++;

                                currentGreenLight = 0;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[wholeTime]}.");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
