using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using SetecBackendCSharp.Models;
using setec_backend_csharp.Models.Core;
using SetecBackendCSharp.Models.Core;


namespace SetecBackendCSharp.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityDate> ActivityDates { get; set; }


    public virtual DbSet<Event> Events { get; set; }


    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<SpeakerSocialMedia> SpeakerSocialMedia { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=ccapstools_app_backend;user=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("activities");


            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(255)
                .HasColumnName("activity_name");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .HasColumnName("activity_type");
            entity.Property(e => e.AimedAudience)
                .HasMaxLength(255)
                .HasColumnName("aimed_audience");
            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.HardSoftwareRequired)
                .HasColumnType("text")
                .HasColumnName("hard_software_required");
            entity.Property(e => e.Local)
                .HasMaxLength(255)
                .HasColumnName("local");
            entity.Property(e => e.Prerequisite)
                .HasColumnType("text")
                .HasColumnName("prerequisite");



            modelBuilder.Entity<ActivityDate>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("activity_dates");

                entity.HasIndex(e => e.ActivityId, "activity_id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");
                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.HasOne(d => d.Activity).WithMany()
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("activity_dates_ibfk_1");
            });



            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");
                entity.Property(e => e.FinalDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("final_date_time");
                entity.Property(e => e.InitialDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("initial_date_time");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("speakers");


                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Bio)
                    .HasColumnType("text")
                    .HasColumnName("bio");
                entity.Property(e => e.Company)
                    .HasMaxLength(255)
                    .HasColumnName("company");
                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<SpeakerSocialMedia>(entity =>
            {
                entity.HasKey(e => new { e.SpeakerId, e.Platform })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("speaker_social_media");

                entity.Property(e => e.SpeakerId).HasColumnName("speaker_id");
                entity.Property(e => e.Platform)
                    .HasMaxLength(50)
                    .HasColumnName("platform");
                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");

                entity.HasOne(d => d.Speaker).WithMany(p => p.SpeakerSocialMedia)
                    .HasForeignKey(d => d.SpeakerId)
                    .HasConstraintName("speaker_social_media_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UK_6dotkott2kjsp8vw4d0m25fb7").IsUnique();

                entity.HasIndex(e => e.Uid, "UK_efqukogbk7i0poucwoy2qie74").IsUnique();

                entity.HasIndex(e => e.Ra, "UK_kb3lfe1v013iq1y3j9i79kug6").IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
                entity.Property(e => e.Ra)
                    .HasMaxLength(13)
                    .HasColumnName("ra");
                entity.Property(e => e.Relationship).HasColumnType("enum('EXALUNO','ALUNO','PROFESSOR','COORDENADOR','SEMRELACAO')");
                entity.Property(e => e.Role).HasColumnType("enum('ADMIN','STUDENT','COMMISSION','SPEAKER')");
                entity.Property(e => e.Uid)
                    .HasMaxLength(36)
                    .HasColumnName("uid");
            });

            OnModelCreatingPartial(modelBuilder);
        });
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
