using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AC = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double kilometers)
        {
            double currentConsumtion = this.FuelConsumption + AC;
            double neededFuel = currentConsumtion * kilometers;

            if (neededFuel > this.FuelQuantity)
            {
                return String.Format(GlobalExceptionMessages.VehicleNeedsRefueling, nameof(Truck));
            }
            else
            {
                this.FuelQuantity -= neededFuel;

                return $"Truck travelled {kilometers} km";
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
                this.FuelQuantity += liters * 0.95;
            }
        }
    }
}
