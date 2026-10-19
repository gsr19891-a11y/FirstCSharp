using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Core.Models.DTOs
{
    public class CreateProductDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }
        int CategoryId { get; set; }
        int BrandId { get; set; }
        string ImageUrl { get; set; }

    }
}
