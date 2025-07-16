using Accountino.Application.DTOs;
using Accountino.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accountino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<List<CategoryDto>> Get()
    {
        return await _categoryService.GetCategoriesAsync();
    }

    [HttpGet("{id}")]
    public async Task<CategoryDto> Get(int id)
    {
        return await _categoryService.GetCategoryByIdAsync(id);
    }

    [HttpPost]
    public async Task Post([FromBody] CreateCategoryDto category)
    {
        await _categoryService.AddCategoryAsync(category);
    }

    [HttpPut]
    public async Task Put([FromBody] CategoryDto category)
    {
        await _categoryService.UpdateCategoryAsync(category);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var categoryToDelete = await _categoryService.GetCategoryByIdAsync(id);

        await _categoryService.RemoveCategoryAsync(categoryToDelete.Id);
    }
}
