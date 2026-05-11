using Clob.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clob.Infrastructure.DataAccess.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.PriceBrl)
            .HasColumnName("price_brl")
            .HasColumnType("decimal(18,8)");

        builder.Property(a => a.PriceBtc)
            .HasColumnName("price_btc")
            .HasColumnType("decimal(18,8)");
    }
}
