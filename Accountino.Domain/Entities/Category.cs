using Accountino.Domain.Common;

namespace Accountino.Domain.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}
