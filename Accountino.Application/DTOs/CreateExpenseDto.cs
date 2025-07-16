namespace Accountino.Application.DTOs;

public class CreateExpenseDto
{
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }

    public int CategoryId { get; set; }
}
