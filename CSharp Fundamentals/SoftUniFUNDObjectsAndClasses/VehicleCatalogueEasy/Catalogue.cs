using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogueEasy
{
    public class Catalogue
    {
        public List<Car> CarList { get; set; }

        public List<Truck> TruckList { get; set; }

        public Catalogue()
        {
            this.CarList = new List<Car>();
            this.TruckList = new List<Truck>();
        }
    }
}
