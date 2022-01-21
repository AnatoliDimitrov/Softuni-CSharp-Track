namespace ChronometerAsync
{
    public class Startup
    {
        public static void Main()
        {
            var chronometer = new Chronometer();

            var line = "";

            while ((line = Console.ReadLine()) != "exit")
            {
                if (line == "start") Task.Run(() => { chronometer.Start(); });
                else if (line == "stop") chronometer.Stop();
                else if (line == "lap") Console.WriteLine(chronometer.Lap());
                else if (line == "reset") chronometer.Reset();
                else if (line == "time") Console.WriteLine(chronometer.GetTime);
                else if (line == "time")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                        continue;
                    }

                    Console.WriteLine("Laps: ");

                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i} {chronometer.Laps[i]}");
                    }
                }
            }

            chronometer.Stop();
        }
    }
}


