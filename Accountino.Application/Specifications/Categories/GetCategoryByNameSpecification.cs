using Accountino.Domain.Common.Specification;
using Accountino.Domain.Entities;

namespace Accountino.Application.Specifications.Categories;

public class GetCategoryByNameSpecification : Specification<Category>
{
    public GetCategoryByNameSpecification(string name)
    {
        Criteria = category => category.Name == name;
    }
}
