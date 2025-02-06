using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFTest;
public class EFTestDbContextFactory : IDesignTimeDbContextFactory<EFTestDbContext>
{

    public EFTestDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFTestDbContext>();
        optionsBuilder.UseSqlite("Data Source=AppFramework.db");

        return new EFTestDbContext(optionsBuilder.Options);
    }
}