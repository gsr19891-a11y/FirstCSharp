using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.DTOs
{
    internal class UpdateCategoryDTO
    {
        string Name { get; set; }
        string ParentCategoryId { get; set; }
    }
}
