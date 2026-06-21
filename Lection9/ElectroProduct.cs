using System;
using System.Collections.Generic;
using System.Text;


//ToString
//GetHashCode
//Equals






namespace Lection9
{
    internal class ElectroProduct : object
    {
        public string Category { get; set; }
        public string Color { get; set; }


        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalit Year");
                    return;
                }
                _price = value;
            }
        }



        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                if (value < DateTime.Now.Year - 20 || value > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalit price");
                    return;
                }
                _price = value;
            }
        }



        private string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Color empty");
                    return;
                }
                _model = value;
            }
        }

    }
}