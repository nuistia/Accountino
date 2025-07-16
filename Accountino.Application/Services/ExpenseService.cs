using Accountino.Application.DTOs;
using Accountino.Application.Interfaces;
using Accountino.Application.Specifications.Expenses;
using Accountino.Domain.Entities;
using AutoMapper;

namespace Accountino.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IRepository<Expense> _repository;
    private readonly IMapper _mapper;

    public ExpenseService(IRepository<Expense> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ExpenseDto>> GetAllAsync()
    {
        var expenses = await _repository.GetAllAsync();
        return _mapper.Map<List<ExpenseDto>>(expenses);
    }

    public async Task<ExpenseDto> GetExpenseByIdAsync(int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        return _mapper.Map<ExpenseDto>(expense);
    }

    public async Task<List<ExpenseDto>> GetExpensesByMonthAsync(int month, int year)
    {
        var expenses = await _repository.GetBySpecification(new GetExpensesByMonthSpecification(month, year));
        return _mapper.Map<List<ExpenseDto>>(expenses);
    }

    public async Task AddExpenseAsync(CreateExpenseDto dto)
    {
        var expense = _mapper.Map<Expense>(dto);
        await _repository.AddAsync(expense);
    }

    public async Task UpdateExpenseAsync(UpdateExpenseDto dto)
    {
        var expense = await _repository.GetByIdAsync(dto.Id);
        if (expense is null) return;

        _mapper.Map(dto, expense);
        await _repository.UpdateAsync(expense);
    }

    public async Task RemoveExpenseAsync(int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense is not null)
        {
            await _repository.DeleteAsync(expense);
        }
    }
}
