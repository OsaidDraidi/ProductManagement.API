﻿namespace ProductManagement.API.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
