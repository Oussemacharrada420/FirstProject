using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EntitiesDbContext>
{
    public EntitiesDbContext CreateDbContext(string[] args = null)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EntitiesDbContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
            b => b.MigrationsAssembly("WebApplication2")); // Update this line

        return new EntitiesDbContext(optionsBuilder.Options);
    }
}
