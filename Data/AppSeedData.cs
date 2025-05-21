using ProductManagement.API.Models;

namespace ProductManagement.API.Data
{
    public static class AppSeedData
    {
        public static List<Category> GetPreconfiguredCategories() => new List<Category>
        {
            new Category {  Name = "Electronics" },
            new Category {  Name = "Books" },
            new Category {  Name = "Clothing" },
            new Category {  Name = "Home Appliances" },
        };

        public static List<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product { Name = "Smartphone", Price = 799.99m, CategoryId = 1 },
            new Product { Name = "Laptop", Price = 1199.00m, CategoryId = 1 },
            new Product { Name = "Bluetooth Headphones", Price = 199.00m, CategoryId = 1 },
            new Product { Name = "Science Fiction Book", Price = 25.50m, CategoryId = 2 },
            new Product { Name = "Programming in C#", Price = 45.00m, CategoryId = 2 },
            new Product { Name = "Children's Story Book", Price = 15.75m, CategoryId = 2 },
            new Product { Name = "T-shirt", Price = 19.99m, CategoryId = 3 },
            new Product { Name = "Jeans", Price = 39.99m, CategoryId = 3 },
            new Product { Name = "Winter Jacket", Price = 89.99m, CategoryId = 3 },
            new Product {  Name = "Microwave Oven", Price = 120.00m, CategoryId = 4 },
            new Product {  Name = "Air Conditioner", Price = 599.99m, CategoryId = 4 },
            new Product {  Name = "Vacuum Cleaner", Price = 150.00m, CategoryId = 4 },
        };
    }
}
