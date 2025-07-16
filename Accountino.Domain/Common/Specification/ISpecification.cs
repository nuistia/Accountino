using System.Linq.Expressions;

namespace Accountino.Domain.Common.Specification;

public class ISpecification<T> where T : IEntity
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}
