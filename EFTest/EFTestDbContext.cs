using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFTest;
public class EFTestDbContext : DbContext
{
    public EFTestDbContext(DbContextOptions<EFTestDbContext> opts) : base(opts) { }

    protected EFTestDbContext(DbContextOptions opts) : base(opts) { }

    public DbSet<Count> Counts { get; set; }
}