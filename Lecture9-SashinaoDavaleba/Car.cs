using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture9_SashinaoDavaleba
{
    internal class Car
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }



        private int _year;
        public int Year
        {
            get {return _year; }

            set
            {
                if(value < DateTime.Now.Year -100 || value > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid Year input!");
                    return;
                }
                _year = value;
            }
        }

        private int _price;
        public int Price
        {
            get {  return _price; }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Invalid Price input!");
                    return;
                }
                _price = value;
            }
        }


        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - {Price}$ - {Color}";
        }

        public void ChangePrice(int price)
        {
            if (price < 0)
            {
                Console.WriteLine("Error Price");
                
            }
             Price = price;
        }


        public void ChangeColor(string color)
        {
             Color = color;
        }


        public void CheckCar()
        {
            if(Year > 2022)
            {
                Console.WriteLine($"{Model} new car!");
            }
            return;
        }


        public int GetAge()
        {
            return DateTime.Now.Year - Year;
        }

        public bool IsNew()
        {
            return GetAge() <= 3;
        }


    }
}
