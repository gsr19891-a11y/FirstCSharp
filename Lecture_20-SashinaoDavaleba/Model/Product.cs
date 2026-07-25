using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_20_SashinaoDavaleba.Model
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string? ToString()
        {
            return $"Name: {Name}, Category: {Category}, Price: {Price}, Stock:{Stock}.";
        }
    }
}
