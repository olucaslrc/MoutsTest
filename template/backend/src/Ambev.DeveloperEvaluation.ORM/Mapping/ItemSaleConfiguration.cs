using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class ItemSaleConfiguration : IEntityTypeConfiguration<ItemSale>
{
    public void Configure(EntityTypeBuilder<ItemSale> builder)
    {
        builder.ToTable("ItemSales");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(i => i.SaleId).IsRequired();
        builder.Property(i => i.ProductId).IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.TotalAmount).IsRequired();
        builder.Property(i => i.Status).IsRequired();

        builder.Property(i => i.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(i => i.UpdatedAt)
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("now()");
    }
}
