using Accountino.Application.DTOs;
using Accountino.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accountino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpensesController(IExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<ExpenseDto>> Get()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ExpenseDto> Get(int id)
    {
        return await _service.GetExpenseByIdAsync(id);
    }

    [HttpPost]
    public async Task Post([FromBody] CreateExpenseDto dto)
    {
        await _service.AddExpenseAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] UpdateExpenseDto dto)
    {
        await _service.UpdateExpenseAsync(dto);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _service.RemoveExpenseAsync(id);
    }
}
