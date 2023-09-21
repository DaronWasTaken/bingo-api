using bingo_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

public partial class BingoDbContext : DbContext
{
    public BingoDbContext()
    {
    }

    public BingoDbContext(DbContextOptions<BingoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<AchievementTask> Achievementtasks { get; set; }

    public virtual DbSet<AuthToken> Authtokens { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Friendship> Friendships { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Quickplay> Quickplays { get; set; }

    public virtual DbSet<ScanObject> Scanobjects { get; set; }

    public virtual DbSet<Timely> Timelies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchievement> Userachievements { get; set; }

    public virtual DbSet<UserQuickplay> Userquickplays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=bingo-dev;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("achievements_pk");

            entity.ToTable("achievements");

            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.BadgeId).HasColumnName("badgeid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.BadgeId)
                .HasConstraintName("fk_0");
        });

        modelBuilder.Entity<AchievementTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("achievementtasks_pk");

            entity.ToTable("achievementtasks");

            entity.Property(e => e.TaskId).HasColumnName("taskid");
            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ObjectToScan).HasColumnName("objecttoscan");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Achievement).WithMany(p => p.AchievementTasks)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_1");

            entity.HasOne(d => d.ObjectToScanNavigation).WithMany(p => p.AchievementTasks)
                .HasForeignKey(d => d.ObjectToScan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_2");
        });

        modelBuilder.Entity<AuthToken>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("authtokens_pk");

            entity.ToTable("authtokens");

            entity.Property(e => e.TokenId).HasColumnName("tokenid");
            entity.Property(e => e.Expiry)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expiry");
            entity.Property(e => e.TokenValue)
                .HasMaxLength(256)
                .HasColumnName("tokenvalue");
            entity.Property(e => e.UserId).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.AuthTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authtokens_users");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("badges_pk");

            entity.ToTable("badges");

            entity.Property(e => e.BadgeId).HasColumnName("badgeid");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("imageurl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Friendship>(entity =>
        {
            entity.HasKey(e => e.FriendshipId).HasName("friends_pk");

            entity.ToTable("friendship");

            entity.Property(e => e.FriendshipId).HasColumnName("friendshipid");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateadded");
            entity.Property(e => e.UserId1).HasColumnName("userid_1");
            entity.Property(e => e.UserId2).HasColumnName("userid_2");

            entity.HasOne(d => d.UserId1Navigation).WithMany(p => p.FriendshipUserId1Navigations)
                .HasForeignKey(d => d.UserId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user1_friendship");

            entity.HasOne(d => d.UserId2Navigation).WithMany(p => p.FriendshipUserId2Navigations)
                .HasForeignKey(d => d.UserId2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user2_friendship");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("levels_pk");

            entity.ToTable("levels");

            entity.Property(e => e.LevelId).HasColumnName("levelid");
            entity.Property(e => e.LevelNumber).HasColumnName("levelnumber");
            entity.Property(e => e.XpRequired).HasColumnName("xprequired");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("locations_pk");

            entity.ToTable("locations");

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
            entity.HasKey(e => e.QuickPlayId).HasName("quickplay_pk");

            entity.ToTable("quickplay");

            entity.Property(e => e.QuickPlayId)
                .ValueGeneratedNever()
                .HasColumnName("quickplayid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.ScanObjectsScanObjectId).HasColumnName("scanobjects_scanobjectid");
            entity.Property(e => e.TimeLimit).HasColumnName("timelimit");
            entity.Property(e => e.Wordset).HasColumnName("wordset");

            entity.HasOne(d => d.ScanObjectsScanObject).WithMany(p => p.QuickPlays)
                .HasForeignKey(d => d.ScanObjectsScanObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quickplay_scanobjects");
        });

        modelBuilder.Entity<ScanObject>(entity =>
        {
            entity.HasKey(e => e.ScanObjectId).HasName("scanobjects_pk");

            entity.ToTable("scanobjects");

            entity.Property(e => e.ScanObjectId).HasColumnName("scanobjectid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LocationId).HasColumnName("locationid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.ScanObjects)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("scanobjects_locations");
        });

        modelBuilder.Entity<Timely>(entity =>
        {
            entity.HasKey(e => e.TimelyId).HasName("timely_pk");

            entity.ToTable("timely");

            entity.Property(e => e.TimelyId)
                .ValueGeneratedNever()
                .HasColumnName("timelyid");
            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Timelies)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("timely_achievements");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("userid");
            entity.Property(e => e.LevelId).HasColumnName("levelid");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Level).WithMany(p => p.Users)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_levels");
        });
        
        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.UserAchievementId).HasName("userachievements_pk");

            entity.ToTable("userachievements");

            entity.Property(e => e.UserAchievementId).HasColumnName("userachievementid");
            entity.Property(e => e.AchievementId).HasColumnName("achievementid");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.DateEarned)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateearned");
            entity.Property(e => e.UserId).HasColumnName("userid");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_4");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_3");
        });

        modelBuilder.Entity<UserQuickplay>(entity =>
        {
            entity.HasKey(e => e.UserQuickPlayId).HasName("userquickplay_pk");

            entity.ToTable("userquickplay");

            entity.Property(e => e.UserQuickPlayId).HasColumnName("userquickplayid");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.DateCompleted)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecompleted");
            entity.Property(e => e.PointsEarned).HasColumnName("pointsearned");
            entity.Property(e => e.QuickPlayQuickPlayId).HasColumnName("quickplay_quickplayid");
            entity.Property(e => e.UsersUserid).HasColumnName("users_userid");

            entity.HasOne(d => d.QuickPlayQuickPlay).WithMany(p => p.UserQuickPlays)
                .HasForeignKey(d => d.QuickPlayQuickPlayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_quickplay");

            entity.HasOne(d => d.UsersUser).WithMany(p => p.UserQuickPlays)
                .HasForeignKey(d => d.UsersUserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_users");
        });
    }
}
