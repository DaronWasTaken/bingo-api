using Microsoft.EntityFrameworkCore;

namespace bingo_api.EfModels;

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

    public virtual DbSet<Quickplayobject> Quickplayobjects { get; set; }

    public virtual DbSet<Scantype> Scantypes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Timely> Timelies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usersachievement> Usersachievements { get; set; }

    public virtual DbSet<Usertask> Usertasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Name=DefaultConnection");
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Achievementid).HasName("achievements_pk");

            entity.ToTable("achievement");

            entity.Property(e => e.Achievementid).HasColumnName("achievementid");
            entity.Property(e => e.Badgeid).HasColumnName("badgeid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Timelyid).HasColumnName("timelyid");

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.Badgeid)
                .HasConstraintName("fk_0");

            entity.HasOne(d => d.Timely).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.Timelyid)
                .HasConstraintName("achievements_timely");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.Badgeid).HasName("badges_pk");

            entity.ToTable("badge");

            entity.Property(e => e.Badgeid).HasColumnName("badgeid");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(255)
                .HasColumnName("imageurl");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Levelnumber).HasName("levels_pk");

            entity.ToTable("levels");

            entity.Property(e => e.Levelnumber).HasColumnName("levelnumber");
            entity.Property(e => e.Requiredpoints).HasColumnName("requiredpoints");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Locationid).HasName("locations_pk");

            entity.ToTable("location");

            entity.Property(e => e.Locationid).HasColumnName("locationid");
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
            entity.HasKey(e => e.Quickplayid).HasName("userquickplay_pk");

            entity.ToTable("quickplay");

            entity.Property(e => e.Quickplayid).HasColumnName("quickplayid");
            entity.Property(e => e.Lastrefreshdate).HasColumnName("lastrefreshdate");
            entity.Property(e => e.Quickplayobjectid).HasColumnName("quickplayobjectid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Quickplayobject).WithMany(p => p.Quickplays)
                .HasForeignKey(d => d.Quickplayobjectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_quickplay");

            entity.HasOne(d => d.User).WithMany(p => p.Quickplays)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userquickplay_users");
        });

        modelBuilder.Entity<Quickplayobject>(entity =>
        {
            entity.HasKey(e => e.Quickplayid).HasName("quickplayobject_pk");

            entity.ToTable("quickplayobject");

            entity.Property(e => e.Quickplayid)
                .ValueGeneratedNever()
                .HasColumnName("quickplayid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Scandate).HasColumnName("scandate");
            entity.Property(e => e.Scanobjectid).HasColumnName("scanobjectid");

            entity.HasOne(d => d.Scanobject).WithMany(p => p.Quickplayobjects)
                .HasForeignKey(d => d.Scanobjectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quickplay_scanobjects");
        });

        modelBuilder.Entity<Scantype>(entity =>
        {
            entity.HasKey(e => e.Scantypeid).HasName("scanobjects_pk");

            entity.ToTable("scantype");

            entity.Property(e => e.Scantypeid).HasColumnName("scantypeid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Locationid).HasColumnName("locationid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.Scantypes)
                .HasForeignKey(d => d.Locationid)
                .HasConstraintName("scanobjects_locations");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Taskid).HasName("achievementtasks_pk");

            entity.ToTable("task");

            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Achievementid).HasColumnName("achievementid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Scanobjectid).HasColumnName("scanobjectid");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Achievementid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_1");

            entity.HasOne(d => d.Scanobject).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Scanobjectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_2");
        });

        modelBuilder.Entity<Timely>(entity =>
        {
            entity.HasKey(e => e.Timelyid).HasName("timely_pk");

            entity.ToTable("timely");

            entity.Property(e => e.Timelyid)
                .ValueGeneratedNever()
                .HasColumnName("timelyid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Levelnumber).HasColumnName("levelnumber");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.LevelnumberNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Levelnumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_levels");
        });

        modelBuilder.Entity<Usersachievement>(entity =>
        {
            entity.HasKey(e => e.Userachievementid).HasName("userachievements_pk");

            entity.ToTable("usersachievements");

            entity.Property(e => e.Userachievementid).HasColumnName("userachievementid");
            entity.Property(e => e.Achievementid).HasColumnName("achievementid");
            entity.Property(e => e.Dateearned)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateearned");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Usersachievements)
                .HasForeignKey(d => d.Achievementid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userachievements_achievements");

            entity.HasOne(d => d.User).WithMany(p => p.Usersachievements)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_3");
        });

        modelBuilder.Entity<Usertask>(entity =>
        {
            entity.HasKey(e => e.Usertaskid).HasName("usertask_pk");

            entity.ToTable("usertask");

            entity.Property(e => e.Usertaskid).HasColumnName("usertaskid");
            entity.Property(e => e.Datecompleted).HasColumnName("datecompleted");
            entity.Property(e => e.Quantitycompleted).HasColumnName("quantitycompleted");
            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Task).WithMany(p => p.Usertasks)
                .HasForeignKey(d => d.Taskid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achievement_tasks_achievementtasks");

            entity.HasOne(d => d.User).WithMany(p => p.Usertasks)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achievement_tasks_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
