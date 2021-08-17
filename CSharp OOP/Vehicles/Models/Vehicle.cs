using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = CheckTankCapacity(fuelQuantity);
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public abstract string Drive(double kilometers);

        public abstract void Refuel(double liters);

        private double CheckTankCapacity(double fuel)
        {
            if (fuel > this.TankCapacity)
            {
                return 0;
            }
            else
            {
                return fuel;
            }
        }
    }
}
