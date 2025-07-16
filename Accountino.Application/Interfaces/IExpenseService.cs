using Accountino.Application.DTOs;

namespace Accountino.Application.Interfaces;

public interface IExpenseService
{
    public Task AddExpenseAsync(CreateExpenseDto dto);
    public Task RemoveExpenseAsync(int id);
    public Task UpdateExpenseAsync(UpdateExpenseDto dto);

    public Task<List<ExpenseDto>> GetAllAsync();
    public Task<ExpenseDto> GetExpenseByIdAsync(int id);
    Task<List<ExpenseDto>> GetExpensesByMonthAsync(int month, int year);
}
