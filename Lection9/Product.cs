using System;
using System.Collections.Generic;
using System.Text;

namespace Lection9
{
    internal class Product
    {
        //კონსტრუქტორი,მშენებელი================================================================================================================================

        public Product() { }

        public Product(string name, decimal price)
        {
            Price = price;
            Name = name;

        }

        public Product(string name, decimal price, bool nuts)
        {
            Price = price;
            Name = name;
            Nuts = nuts;

        }




        public int Id { get; set; }
        public string Name { get; set; }
        public bool Nuts { get; set; }
        public string Image { get; set; }
        public bool Vegetarian { get; set; }
        public int Spiciness { get; set; }
        public string Category { get; set; }




        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (Price < 0)
                {
                    Console.WriteLine("Invalid Price");
                    return;
                }

                _price = value;

            }
        }

        public void Print()
        {
             Console.WriteLine($"Name:{Name}, Price: {Price}");
        }

        public override string ToString()
        {
           return  $"Name:{Name}, Price: {Price}";
        }

        public bool IsNutAndVegiterian()
        {
            return Nuts & Vegetarian;
        }
    }

}
