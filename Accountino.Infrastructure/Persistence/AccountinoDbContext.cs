using Accountino.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accountino.Infrastructure.Persistence;

public class AccountinoDbContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public AccountinoDbContext(DbContextOptions<AccountinoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountinoDbContext).Assembly);
    }
}
