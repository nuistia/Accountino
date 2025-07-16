using Accountino.Application.DTOs;

namespace Accountino.Application.Interfaces;

public interface ICategoryService
{
    public Task AddCategoryAsync(CreateCategoryDto category);
    public Task RemoveCategoryAsync(int id);
    public Task UpdateCategoryAsync(CategoryDto category);

    public Task<List<CategoryDto>> GetCategoriesAsync();
    public Task<CategoryDto> GetCategoryByIdAsync(int id);
    public Task<CategoryDto> GetCategoryByNameAsync(string name);
}
