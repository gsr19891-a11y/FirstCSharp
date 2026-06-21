using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture9_SashinaoDavaleba
{
    internal class Appliances
    {
        public string Type;
        public string Brand;
        public string Model;
        public bool HasWifi;


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

    }
}
