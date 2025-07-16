using Accountino.Domain.Common.Specification;
using Accountino.Domain.Entities;

namespace Accountino.Application.Specifications.Expenses;

public class GetExpensesByMonthSpecification : Specification<Expense>
{
    public GetExpensesByMonthSpecification(DateTime month)
    {
        Criteria = expense => expense.Date.Month.Equals(month);
        AddInclude(c => c.Category);
    } 
}
