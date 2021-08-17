using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine();

            try
            {
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
