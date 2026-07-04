using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12_AisDavalebebi.Interfaces.Models
{
    internal class Electronics : Product
    {
        public int WarrantyMonths { get; set; }

        public Electronics(string name, int price, int warrantyMonths) : base(name, price)
        {
            WarrantyMonths = warrantyMonths;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"[Электроника] ID: {Id} | Название: {Name} | Цена: {Price}₾ | Гарантия: {WarrantyMonths} мес.");
        }
    }
}
