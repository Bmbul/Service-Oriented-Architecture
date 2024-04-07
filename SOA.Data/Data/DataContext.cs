using Microsoft.EntityFrameworkCore;
using SOA.Data.Entities;

namespace SOA.Data.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; } = null!;
}
