namespace Facade
{
    public class StartUp
    {
        static void Main()
        {
            var car = new CarBuilderFacade()
                .Info
                .WithType("Zastava")
                .WithColor("Orange")
                .WithNumberOfDoors(5)
                .Built
                .InCity("Berlin")
                .AtAddress("Top Secret")
                .Build();

            System.Console.WriteLine(car);
        }
    }
}
