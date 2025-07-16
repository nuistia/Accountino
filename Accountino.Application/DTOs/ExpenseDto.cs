namespace Accountino.Application.DTOs;

public class ExpenseDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
