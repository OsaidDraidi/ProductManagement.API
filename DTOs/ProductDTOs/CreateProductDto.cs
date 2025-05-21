﻿using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ProductManagement.API.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity {  get; set; }
        public int CategoryId {  get; set; }

    }
}
