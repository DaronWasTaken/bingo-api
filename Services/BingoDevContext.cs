using Microsoft.EntityFrameworkCore;

namespace bingo_api.EfModels;


//TODO: CHECK DB CONTEXT
public partial class BingoDevContext : DbContext
{
    public BingoDevContext()
    {
    }

    public BingoDevContext(DbContextOptions<BingoDevContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Quickplay> Quickplays { get; set; }

    public virtual DbSet<QuickplayObject> Quickplayobjects { get; set; }

    public virtual DbSet<ScanType> Scantypes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Timely> Timelies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchievement> Usersachievements { get; set; }

    public virtual DbSet<UserTask> Usertasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Name=DefaultConnection");
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("achievements_pk");

            entity.ToTable("achievement");

            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.BadgeId).HasColumnName("badgeid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.TimelyId).HasColumnName("timelyid");

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.BadgeId)
                .HasConstraintName("fk_0");

            entity.HasOne(d => d.Timely).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.TimelyId)
                .HasConstraintName("achievements_timely");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("badges_pk");

            entity.ToTable("badge");

            entity.Property(e => e.BadgeId).HasColumnName("badgeid");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("imageurl");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelNumber).HasName("levels_pk");

            entity.ToTable("levels");

            entity.Property(e => e.LevelNumber).HasColumnName("levelnumber");
            entity.Property(e => e.RequiredPoints).HasColumnName("requiredpoints");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("locations_pk");

            entity.ToTable("location");

            entity.Property(e => e.LocationId).HasColumnName("locationid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 8)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(11, 8)
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Radius)
                .HasPrecision(5, 2)
                .HasColumnName("radius");
        });

        modelBuilder.Entity<Quickplay>(entity =>
        {
            entity.HasKey(e => e.QuickplayId).HasName("userquickplay_pk");

            entity.ToTable("quickplay");

            entity.Property(e => e.QuickplayId).HasColumnName("quickplayid");
            entity.Property(e => e.LastRefreshDate).HasColumnName("lastrefreshdate");
            entity.Property(e => e.QuickplayObjectId).HasColumnName("quickplayobjectid");
            entity.Property(e => e.UserId).HasColumnName("userid");

            entity.HasOne(d => d.QuickplayObject).WithMany(p => p.Quickplays)
                .HasForeignKey(d => d.QuickplayObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_quickplay");

            entity.HasOne(d => d.User).WithMany(p => p.Quickplays)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_users");
        });

        modelBuilder.Entity<QuickplayObject>(entity =>
        {
            entity.HasKey(e => e.QuickplayId).HasName("quickplayobject_pk");

            entity.ToTable("quickplayobject");

            entity.Property(e => e.QuickplayId)
                .ValueGeneratedNever()
                .HasColumnName("quickplayid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.ScanDate).HasColumnName("scandate");
            entity.Property(e => e.ScanTypeId).HasColumnName("scantypeid");

            entity.HasOne(d => d.ScanType).WithMany(p => p.QuickplayObjects)
                .HasForeignKey(d => d.ScanTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quickplay_scantype");
        });

        modelBuilder.Entity<ScanType>(entity =>
        {
            entity.HasKey(e => e.ScanTypeId).HasName("scanobjects_pk");

            entity.ToTable("scantype");

            entity.Property(e => e.ScanTypeId).HasColumnName("scantypeid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LocationId).HasColumnName("locationid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.ScanTypes)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("scanobjects_locations");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("achievementtasks_pk");

            entity.ToTable("task");

            entity.Property(e => e.TaskId).HasColumnName("taskid");
            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ScanTypeId).HasColumnName("scantypeid");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_1");

            entity.HasOne(d => d.ScanType).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ScanTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_2");
        });

        modelBuilder.Entity<Timely>(entity =>
        {
            entity.HasKey(e => e.TimelyId).HasName("timely_pk");

            entity.ToTable("timely");

            entity.Property(e => e.TimelyId)
                .ValueGeneratedNever()
                .HasColumnName("timelyid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndTime).HasColumnName("endtime");
            entity.Property(e => e.StartTime).HasColumnName("starttime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("userid");
            entity.Property(e => e.LevelNumber).HasColumnName("levelnumber");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.LevelNumberNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.LevelNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_levels");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.Userachievementid).HasName("userachievements_pk");

            entity.ToTable("userachievement");

            entity.Property(e => e.Userachievementid).HasColumnName("userachievementid");
            entity.Property(e => e.Achievementid).HasColumnName("achievementid");
            entity.Property(e => e.Dateearned)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateearned");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UsersAchievements)
                .HasForeignKey(d => d.Achievementid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userachievements_achievements");

            entity.HasOne(d => d.User).WithMany(p => p.UsersAchievements)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_3");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.UserTaskId).HasName("usertask_pk");

            entity.ToTable("usertask");

            entity.Property(e => e.UserTaskId).HasColumnName("usertaskid");
            entity.Property(e => e.DateCompleted).HasColumnName("datecompleted");
            entity.Property(e => e.QuantityCompleted).HasColumnName("quantitycompleted");
            entity.Property(e => e.TaskId).HasColumnName("taskid");
            entity.Property(e => e.UserId).HasColumnName("userid");

            entity.HasOne(d => d.Task).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achievement_tasks_achievementtasks");

            entity.HasOne(d => d.User).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achievement_tasks_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
