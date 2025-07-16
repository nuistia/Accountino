using Accountino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountino.Infrastructure.Persistence.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");

        builder.HasIndex(c => c.Id)
            .IsUnique();

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("Id");
        builder.Property(e => e.Price)
            .HasPrecision(2)
            .IsRequired();
        builder.Property(e => e.CategoryId)
            .IsRequired();

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
