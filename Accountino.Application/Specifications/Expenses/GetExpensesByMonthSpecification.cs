using Accountino.Domain.Common.Specification;
using Accountino.Domain.Entities;

namespace Accountino.Application.Specifications.Expenses;

public class GetExpensesByMonthSpecification : Specification<Expense>
{
    public GetExpensesByMonthSpecification(int month, int year)
    {
        Criteria = expense => expense.Date.Month == month && expense.Date.Year == year;
        AddInclude(c => c.Category);
    } 
}
