using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Models.Entities;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Subtask> Subtasks { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<UserItem> UserItems { get; set; }

    public virtual DbSet<UserSubtask> UserSubtasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achievements_pk");

            entity.ToTable("achievement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BadgeFile).HasColumnName("badge_file");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.TotalSubtasks).HasColumnName("total_subtasks");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scanobjects_pk");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("level_pk");

            entity.ToTable("level");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequiredPoints).HasColumnName("required_points");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("locations_pk");

            entity.ToTable("location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Latitude)
                .HasPrecision(9, 6)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(9, 6)
                .HasColumnName("longitude");
            entity.Property(e => e.Radius).HasColumnName("radius");
        });

        modelBuilder.Entity<Subtask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subtask_pk");

            entity.ToTable("subtask");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievement_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageFile)
                .HasMaxLength(255)
                .HasColumnName("image_file");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TotalNumber).HasColumnName("total_number");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Subtasks)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subtask_achievement");

            entity.HasOne(d => d.Item).WithMany(p => p.Subtasks)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("subtask_item");

            entity.HasOne(d => d.Location).WithMany(p => p.Subtasks)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("subtask_location");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_achievement_pk");

            entity.ToTable("user_achievement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievementId).HasColumnName("achievement_id");
            entity.Property(e => e.CompletedSubtasks).HasColumnName("completed_subtasks");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_ach_achievement");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_ach_usr");
        });

        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_item_pk");

            entity.ToTable("user_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Item).WithMany(p => p.UserItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_item_item");

            entity.HasOne(d => d.User).WithMany(p => p.UserItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_item_usr");
        });

        modelBuilder.Entity<UserSubtask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_subtask_pk");

            entity.ToTable("user_subtask");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumberCompleted).HasColumnName("number_completed");
            entity.Property(e => e.SubtaskId).HasColumnName("subtask_id");
            entity.Property(e => e.UserAchievementId).HasColumnName("user_achievement_id");

            entity.HasOne(d => d.Subtask).WithMany(p => p.UserSubtasks)
                .HasForeignKey(d => d.SubtaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_sub_subtask");

            entity.HasOne(d => d.UserAchievement).WithMany(p => p.UserSubtasks)
                .HasForeignKey(d => d.UserAchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_sub_usr_ach");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usr_pk");

            entity.ToTable("usr");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Level).WithMany(p => p.Usrs)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_level");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
