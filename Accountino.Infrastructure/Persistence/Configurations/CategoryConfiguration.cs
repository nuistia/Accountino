using Accountino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountino.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasIndex(c => c.Id)
            .IsUnique();

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("Id");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("Name")
            .IsRequired();
    }
}
