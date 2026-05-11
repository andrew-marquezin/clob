using Clob.Domain.Abstractions;
using Clob.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clob.Infrastructure.DataAccess;

public sealed class ClobDbContext(DbContextOptions<ClobDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClobDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
