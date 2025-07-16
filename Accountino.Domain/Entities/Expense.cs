using Accountino.Domain.Common;

namespace Accountino.Domain.Entities;

public class Expense : IEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
