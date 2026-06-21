using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture9_SashinaoDavaleba
{
    internal class Appliances
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool HasWifi { get; set; }


        private int _price;
        public int Price
        {
            get => _price; set
            {
                if (value < 0)
                {
                    return;
                }
                _price = value;
            }
        }



        private int _powerUsage;
        public int PowerUsage
        {
            get => _powerUsage; set
            {
                if (value < 0)
                {
                    return;
                }
                _powerUsage = value;
            }
        }

        public override string ToString()
        {
            return $"Type:{Type}, Brand: {Brand}, Model:{Model}, Price: {Price}$, Power Usage: {PowerUsage}, Has WiFi: {HasWifi}.";
        }



        public double GetMonthlyElectricityCost(double pricePerKwh)
        {
            if (pricePerKwh < 0)
            {
                return 0;
            }

            double power = (PowerUsage / 1000) * 60;
            return power * pricePerKwh;
        }

        public bool IsEnergyEfficient()
        {
            if (PowerUsage < 1000)
            {
                return true;
            }
            return false;
        }

        public bool ToggleWifi()
        {
            return HasWifi = !HasWifi;
        }


        public void ApplyDiscount(int percent)
        {
            if (percent < 0 || percent > 100) { return; }

            double discount = Price * (percent / 100.0);

            Price = Price - (int)discount;
        }


    }
}
