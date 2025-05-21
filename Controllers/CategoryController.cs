using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DTOs.CategoryDTOs;
using ProductManagement.API.Models;
using ProductManagement.API.Services.Interface;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null) { return NotFound(); }

            var category = _mapper.Map<Category>(createCategoryDto);

            var createdCategory = await _categoryService.CreateAsync(category);

            var createdDto = _mapper.Map<CategoryDto>(createdCategory);

            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto == null) { return BadRequest(); }
            var updateCategory = _mapper.Map<Category>(updateCategoryDto);
            var success = await _categoryService.UpdateAsync(id, updateCategory);

            if (!success) { return NotFound(); }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _categoryService.DeleteAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
