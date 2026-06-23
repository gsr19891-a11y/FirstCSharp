using Lecture_10.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    //internal მხოლოდ მოცემულ პროექტში ჩანს;




    internal class Car
    {

        public Car(string maker, string model, int year, decimal price, Color color)
        {
            Maker = maker;
            Model = model;
            Year = year;
            Price = price;
            Color = color;
        }

        public Car()
        {

        }

        private string _maker;
        public string Maker
        {
            get { return _maker; }
            set { _maker = value; }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }


        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public Color Color { get; set; }


        public override string ToString()//გადაფარვა
        {
            return $"Model: {Model}, Maker: {Maker}, Year: {Year}, Price:{Price}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Car car)
            {
                return Maker == car.Maker && Model == car.Model && Price == car.Price && Year == car.Year && Color == car.Color;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Maker, Model, Price, Year, Color);
        }
    }


}


//override გადაფარვა მშობლის მეთოდის