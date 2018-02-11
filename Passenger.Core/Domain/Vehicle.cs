using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }
        public int Sits { get; protected set; }
        public string Brand { get; protected set; }

        protected Vehicle()
        {
            
        }

        protected Vehicle(string brand, string name, int sits)
        {
            SetBrand(brand);
            SetName(name);
            SetSits(sits);
        }

        private void SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("Vehgicle's name must not be empty");
            }

            if (Name==name) return;

            this.Name = name;
        }

        private void SetBrand(string brand)
        {
            if (String.IsNullOrEmpty(brand)) throw new Exception("Brand can not be empty.");

            if (Brand==brand) return;

            Brand = brand;
        }

        private void SetSits(int sits)
        {
            if (sits<1) throw new Exception("Invalid number of sit's");
            if (sits>9) throw new Exception("Number of sits can't be greater than 9");
            if (Sits==sits) return;

            Sits=sits;
        }

        public static Vehicle Create(string brand, string name, int sits)
            => new Vehicle(brand, name, sits);

    }
}