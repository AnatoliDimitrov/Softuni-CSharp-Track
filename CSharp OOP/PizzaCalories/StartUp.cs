using System;

namespace Pizza
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();

            try
            {

                engine.Run();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
