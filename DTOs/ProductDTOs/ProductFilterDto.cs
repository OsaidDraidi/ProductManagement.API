namespace ProductManagement.API.DTOs.ProductDTOs
{
    public class ProductFilterDto
    {
        public string? Search { get; set; }          
        public int? CategoryId { get; set; }         
        public decimal? MinPrice { get; set; }       
        public decimal? MaxPrice { get; set; }

        public string? SortBy { get; set; } // "name", "price"
        public string? SortDirection { get; set; } // "asc" or "desc"

        public int PageNumber { get; set; } = 1; // رقم الصفحة الحالية
        public int PageSize { get; set; } = 10; // عدد العناصر في كل صفحة


    }
}
