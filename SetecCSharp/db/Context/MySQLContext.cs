using Microsoft.EntityFrameworkCore;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Models.Implementations.Date;
using SetecCSharp.Models.Implementations.Event;
using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Models.Implementations.TypeActivity;
using SetecCSharp.Models.Implementations.User;

namespace SetecCSharp.db.Context;

public class MySQLContext : DbContext
{
    public MySQLContext() { }
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<SpeakerModel> Speakers { get; set; }
    public DbSet<EventModel> Events { get; set; }
    public DbSet<TypeActivityModel> TypeActivities { get; set; }
    public DbSet<ActivityModel> Activities { get; set; }
    public DbSet<DateModel> Dates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasIndex(u => u.Uid)
            .IsUnique();

        modelBuilder.Entity<SpeakerModel>()
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<SpeakerModel>(s => s.Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SpeakerModel>()
            .HasOne<UserModel>() // sem propriedade de navegação
            .WithMany()
            .HasPrincipalKey(u => u.Uid)
            .HasForeignKey(s => s.AdminUid)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ActivityModel>()
            .HasOne(a => a.Event)
            .WithMany(e => e.Activities)
            .HasForeignKey(a => a.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ActivityModel>()
            .HasOne(a => a.TypeActivity)
            .WithMany(t => t.Activities)
            .HasForeignKey(a => a.TypeActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DateModel>()
            .HasOne(d => d.Activity)
            .WithMany(a => a.Dates)
            .HasForeignKey(d => d.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

}