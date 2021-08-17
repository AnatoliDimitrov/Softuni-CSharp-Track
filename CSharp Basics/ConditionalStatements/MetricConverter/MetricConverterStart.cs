namespace MetricConverter
{
    using System;
    class MetricConverterStart
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            string metric = Console.ReadLine();
            string metricToConvert = Console.ReadLine();

            if (metric == "m")
            {
                if (metricToConvert == "cm")
                {
                    Console.WriteLine("{0:0.000}", number * 100.0);
                }
                else if (metricToConvert == "mm")
                {
                    Console.WriteLine("{0:0.000}", number * 1000.0);
                }
            }
            else if (metric == "cm")
            {
                if (metricToConvert == "m")
                {
                    Console.WriteLine("{0:0.000}", number / 100.0);
                }
                else if (metricToConvert == "mm")
                {
                    Console.WriteLine("{0:0.000}", number * 10.0);
                }
            }
            else
            {
                if (metricToConvert == "m")
                {
                    Console.WriteLine("{0:0.000}", number / 1000.0);
                }
                else if (metricToConvert == "cm")
                {
                    Console.WriteLine("{0:0.000}", number / 10.0);
                }
            }
        }
    }
}
