namespace CarShop.ViewModels
{
    public class CarsAllVieModel
    {
        public string Id { get; init; }

        public string Model { get; init; }

        public string PlateNumber { get; init; }

        public string PictureUrl { get; init; }

        public int Fixed { get; set; }

        public int UnFixed { get; set; }
    }
}
