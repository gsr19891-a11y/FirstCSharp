using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.DTOs
{
    public class CreateCategoryDTO
    {
        string Name { get; set; }
        string ParentCategoryId { get; set; }
    }
}
