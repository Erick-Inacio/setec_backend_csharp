using Microsoft.EntityFrameworkCore;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Models.Implementations.User;

namespace SetecCSharp.db.Context;

public class MySQLContext : DbContext
{
    public MySQLContext() { }
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<SpeakerModel> Speakers { get; set; }
    public DbSet<EventModel> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasIndex(u => u.Uid)
            .IsUnique();

        modelBuilder.Entity<SpeakerModel>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SpeakerModel>()
                .HasOne<UserModel>() // sem propriedade de navegação
                .WithMany()
                .HasPrincipalKey(u => u.Uid)
                .HasForeignKey(s => s.AdminUid)
                .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

}