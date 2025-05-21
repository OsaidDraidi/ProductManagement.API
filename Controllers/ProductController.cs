using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DTOs.ProductDTOs;
using ProductManagement.API.Models;
using ProductManagement.API.Services.Interface;

namespace ProductManagement.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return NotFound();
            }
            var product = _mapper.Map<Product>(createProductDto);

            var created = await _service.CreateAsync(product);

            var createdDto = _mapper.Map<ProductDto>(created);

            if (created == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return NotFound();
            }
            var product = _mapper.Map<Product>(createProductDto);

            var updated = await _service.UpdateAsync(id, product);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            return Ok(deleted);
        }

        [HttpGet ("filter")]
        public async Task<IActionResult> Filter([FromQuery] ProductFilterDto productFilterDto)
        {
            var products=await _service.FilterAsync(productFilterDto);
            var productsDto=_mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }
    }
}
