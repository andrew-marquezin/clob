using Clob.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clob.Infrastructure.DataAccess.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.BalanceBrl)
            .HasColumnName("balance_brl")
            .HasColumnType("decimal(18,8)");

        builder.Property(a => a.BalanceBtc)
            .HasColumnName("balance_btc")
            .HasColumnType("decimal(18,8)");

        // Seeding
        builder.HasData(
            new Account(Guid.Parse("11111111-1111-1111-1111-111111111111"), 2.5m, 10000m),
            new Account(Guid.Parse("22222222-2222-2222-2222-222222222222"), 0.5m, 50000m)
        );
    }
}
