using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    class Bus : Vehicle
    {
        private const double AC = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double kilometers)
        {
            double currentConsumtion = this.FuelConsumption + AC;
            double neededFuel = currentConsumtion * kilometers;

            if (neededFuel > this.FuelQuantity)
            {
                return String.Format(GlobalExceptionMessages.VehicleNeedsRefueling, nameof(Bus));
            }
            else
            {
                this.FuelQuantity -= neededFuel;

                return $"Bus travelled {kilometers} km";
            }
        }

        public string DriveEmpty(double kilometers)
        {
            double currentConsumtion = this.FuelConsumption;
            double neededFuel = currentConsumtion * kilometers;

            if (neededFuel > this.FuelQuantity)
            {
                return String.Format(GlobalExceptionMessages.VehicleNeedsRefueling, nameof(Bus));
            }
            else
            {
                this.FuelQuantity -= neededFuel;

                return $"Bus travelled {kilometers} km";
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(GlobalExceptionMessages.NoFuelToAdd);
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(GlobalExceptionMessages.CannotFitFuel, liters));
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
    }
}
