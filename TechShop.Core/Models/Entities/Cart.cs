using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
