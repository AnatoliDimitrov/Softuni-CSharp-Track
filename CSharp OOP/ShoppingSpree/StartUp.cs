using System;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();

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
