using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12_AisDavalebebi.Interfaces.Models
{
    internal abstract class Product : IStorable
    {
     private static int _idCounter = 1;

        public Product(string name, int price) {
        Id = _idCounter++;
        Name = name;
        Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public abstract void PrintDetails();
    }
}
