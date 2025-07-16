using Accountino.Application.DTOs;
using Accountino.Application.Interfaces;
using Accountino.Application.Specifications.Categories;
using Accountino.Domain.Entities;
using AutoMapper;

namespace Accountino.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task AddCategoryAsync(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _repository.AddAsync(category);
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> GetCategoryByNameAsync(string name)
    {
        // Every category is unique so there will be 1 element
        var category = await _repository.GetBySpecification(new GetCategoryByNameSpecification(name));
        var found = category.First();

        return _mapper.Map<CategoryDto>(found);
    }

    public async Task RemoveCategoryAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(category);
    }

    public async Task UpdateCategoryAsync(CategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(dto.Id);
        category.ChangeName(dto.Name);
        await _repository.UpdateAsync(category);
    }
}
