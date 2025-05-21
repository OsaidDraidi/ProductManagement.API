using AutoMapper;
using ProductManagement.API.DTOs.CategoryDTOs;
using ProductManagement.API.DTOs.ProductDTOs;
using ProductManagement.API.Models;

namespace ProductManagement.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 

            CreateMap<Product,ProductDto>();
            CreateMap<CreateProductDto,Product>();

            CreateMap<Category,CategoryDto>();
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<UpdateCategoryDto,Category>();

        }
    }
}
