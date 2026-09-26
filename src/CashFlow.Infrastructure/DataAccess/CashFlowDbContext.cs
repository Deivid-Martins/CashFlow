using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Host=ep-fancy-fire-acda0gon-pooler.sa-east-1.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_pXwFcuIxZ0J8; SSL Mode=VerifyFull; Channel Binding=Require;";

        optionsBuilder.UseNpgsql(connectionString);
    }
}
