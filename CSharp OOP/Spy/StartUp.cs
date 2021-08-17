using System;

namespace Spy
{
    [Author("Venci")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
