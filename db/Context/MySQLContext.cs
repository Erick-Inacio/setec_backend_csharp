using Microsoft.EntityFrameworkCore;
using SetecBackendCSharp.Models.Implementations.UserModel;

namespace SetecBackendCSharp.db.Context;

public class MySQLContext : DbContext
{
    public MySQLContext() { }
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}