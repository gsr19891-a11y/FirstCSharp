using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.Entities
{
    public abstract class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentCategoryId { get; set; }
    }
}
