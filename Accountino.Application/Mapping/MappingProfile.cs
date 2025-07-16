using Accountino.Application.DTOs;
using Accountino.Domain.Entities;
using AutoMapper;

namespace Accountino.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<CreateCategoryDto, Category>()
            .ConstructUsing(dto => new Category(dto.Name));
    }
}
