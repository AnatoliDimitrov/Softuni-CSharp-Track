using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.ViewModels
{
    public class CarIssuesViewModel
    {
        public string CarId { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
