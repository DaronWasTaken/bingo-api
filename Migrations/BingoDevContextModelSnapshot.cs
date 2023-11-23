﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bingo_api.Models;

#nullable disable

namespace bingo_api.Migrations
{
    [DbContext(typeof(BingoDevContext))]
    partial class BingoDevContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("achievementid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AchievementId"));

                    b.Property<int?>("BadgeId")
                        .HasColumnType("integer")
                        .HasColumnName("badgeid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int?>("TimelyId")
                        .HasColumnType("integer")
                        .HasColumnName("timelyid");

                    b.HasKey("AchievementId")
                        .HasName("achievements_pk");

                    b.HasIndex("BadgeId");

                    b.HasIndex("TimelyId");

                    b.ToTable("achievement", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("badgeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BadgeId"));

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("imageurl");

                    b.HasKey("BadgeId")
                        .HasName("badges_pk");

                    b.ToTable("badge", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Level", b =>
                {
                    b.Property<int>("LevelNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("levelnumber");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LevelNumber"));

                    b.Property<int>("RequiredPoints")
                        .HasColumnType("integer")
                        .HasColumnName("requiredpoints");

                    b.HasKey("LevelNumber")
                        .HasName("levels_pk");

                    b.ToTable("level", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("locationid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(10, 8)
                        .HasColumnType("numeric(10,8)")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("numeric(11,8)")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Radius")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("radius");

                    b.HasKey("LocationId")
                        .HasName("locations_pk");

                    b.ToTable("location", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Quickplay", b =>
                {
                    b.Property<int>("QuickplayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("quickplayid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuickplayId"));

                    b.Property<DateTime?>("LastRefreshDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lastrefreshdate");

                    b.Property<int>("QuickplayObjectId")
                        .HasColumnType("integer")
                        .HasColumnName("quickplayobjectid");

                    b.Property<DateTime?>("ScanDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("scandate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("QuickplayId")
                        .HasName("userquickplay_pk");

                    b.HasIndex("QuickplayObjectId");

                    b.HasIndex("UserId");

                    b.ToTable("quickplay", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.QuickplayObject", b =>
                {
                    b.Property<int>("QuickplayObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("quickplayobjectid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuickplayObjectId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<int>("ScantypeId")
                        .HasColumnType("integer")
                        .HasColumnName("scantypeid");

                    b.HasKey("QuickplayObjectId")
                        .HasName("quickplayobject_pk");

                    b.HasIndex("ScantypeId");

                    b.ToTable("quickplayobject", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.ScanType", b =>
                {
                    b.Property<int>("ScanTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("scantypeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScanTypeId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer")
                        .HasColumnName("locationid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("ScanTypeId")
                        .HasName("scanobjects_pk");

                    b.HasIndex("LocationId");

                    b.ToTable("scantype", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.TaskEntity", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("taskid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskId"));

                    b.Property<int>("AchievementId")
                        .HasColumnType("integer")
                        .HasColumnName("achievementid");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int>("ScantypeId")
                        .HasColumnType("integer")
                        .HasColumnName("scantypeid");

                    b.HasKey("TaskId")
                        .HasName("achievementtasks_pk");

                    b.HasIndex("AchievementId");

                    b.HasIndex("ScantypeId");

                    b.ToTable("task", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.Timely", b =>
                {
                    b.Property<int>("TimelyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("timelyid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TimelyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("endtime");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("starttime");

                    b.HasKey("TimelyId")
                        .HasName("timely_pk");

                    b.ToTable("timely", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("LevelNumber")
                        .HasColumnType("integer")
                        .HasColumnName("levelnumber");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("LevelNumber");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.UserAchievement", b =>
                {
                    b.Property<int>("UserAchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("userachievementid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserAchievementId"));

                    b.Property<int>("AchievementId")
                        .HasColumnType("integer")
                        .HasColumnName("achievementid");

                    b.Property<DateTime?>("DateEarned")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dateearned");

                    b.Property<string>("Userid")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("UserAchievementId")
                        .HasName("userachievements_pk");

                    b.HasIndex("AchievementId");

                    b.HasIndex("Userid");

                    b.ToTable("userachievement", (string)null);
                });

            modelBuilder.Entity("bingo_api.Models.UserTask", b =>
                {
                    b.Property<int>("UserTaskid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("usertaskid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserTaskid"));

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datecompleted");

                    b.Property<int>("QuantityCompleted")
                        .HasColumnType("integer")
                        .HasColumnName("quantitycompleted");

                    b.Property<int>("TaskId")
                        .HasColumnType("integer")
                        .HasColumnName("taskid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("UserTaskid")
                        .HasName("usertask_pk");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("usertask", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("bingo_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("bingo_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bingo_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("bingo_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bingo_api.Models.Achievement", b =>
                {
                    b.HasOne("bingo_api.Models.Badge", "Badge")
                        .WithMany("Achievements")
                        .HasForeignKey("BadgeId")
                        .HasConstraintName("fk_0");

                    b.HasOne("bingo_api.Models.Timely", "Timely")
                        .WithMany("Achievements")
                        .HasForeignKey("TimelyId")
                        .HasConstraintName("achievements_timely");

                    b.Navigation("Badge");

                    b.Navigation("Timely");
                });

            modelBuilder.Entity("bingo_api.Models.Quickplay", b =>
                {
                    b.HasOne("bingo_api.Models.QuickplayObject", "QuickplayObject")
                        .WithMany("Quickplays")
                        .HasForeignKey("QuickplayObjectId")
                        .IsRequired()
                        .HasConstraintName("userquickplay_quickplay");

                    b.HasOne("bingo_api.Models.User", "User")
                        .WithMany("Quickplays")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("userquickplay_users");

                    b.Navigation("QuickplayObject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bingo_api.Models.QuickplayObject", b =>
                {
                    b.HasOne("bingo_api.Models.ScanType", "ScanType")
                        .WithMany("QuickplayObjects")
                        .HasForeignKey("ScantypeId")
                        .IsRequired()
                        .HasConstraintName("quickplay_scanobjects");

                    b.Navigation("ScanType");
                });

            modelBuilder.Entity("bingo_api.Models.ScanType", b =>
                {
                    b.HasOne("bingo_api.Models.Location", "Location")
                        .WithMany("ScanTypes")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("scanobjects_locations");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("bingo_api.Models.TaskEntity", b =>
                {
                    b.HasOne("bingo_api.Models.Achievement", "Achievement")
                        .WithMany("Tasks")
                        .HasForeignKey("AchievementId")
                        .IsRequired()
                        .HasConstraintName("fk_1");

                    b.HasOne("bingo_api.Models.ScanType", "ScanType")
                        .WithMany("Tasks")
                        .HasForeignKey("ScantypeId")
                        .IsRequired()
                        .HasConstraintName("fk_2");

                    b.Navigation("Achievement");

                    b.Navigation("ScanType");
                });

            modelBuilder.Entity("bingo_api.Models.User", b =>
                {
                    b.HasOne("bingo_api.Models.Level", "LevelNumberNavigation")
                        .WithMany("Users")
                        .HasForeignKey("LevelNumber")
                        .IsRequired()
                        .HasConstraintName("users_levels");

                    b.Navigation("LevelNumberNavigation");
                });

            modelBuilder.Entity("bingo_api.Models.UserAchievement", b =>
                {
                    b.HasOne("bingo_api.Models.Achievement", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementId")
                        .IsRequired()
                        .HasConstraintName("userachievements_achievements");

                    b.HasOne("bingo_api.Models.User", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("fk_3");

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bingo_api.Models.UserTask", b =>
                {
                    b.HasOne("bingo_api.Models.TaskEntity", "TaskEntity")
                        .WithMany("UserTasks")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("user_achievement_tasks_achievementtasks");

                    b.HasOne("bingo_api.Models.User", "User")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("user_achievement_tasks_users");

                    b.Navigation("TaskEntity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("bingo_api.Models.Achievement", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("UserAchievements");
                });

            modelBuilder.Entity("bingo_api.Models.Badge", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("bingo_api.Models.Level", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("bingo_api.Models.Location", b =>
                {
                    b.Navigation("ScanTypes");
                });

            modelBuilder.Entity("bingo_api.Models.QuickplayObject", b =>
                {
                    b.Navigation("Quickplays");
                });

            modelBuilder.Entity("bingo_api.Models.ScanType", b =>
                {
                    b.Navigation("QuickplayObjects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("bingo_api.Models.TaskEntity", b =>
                {
                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("bingo_api.Models.Timely", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("bingo_api.Models.User", b =>
                {
                    b.Navigation("Quickplays");

                    b.Navigation("UserAchievements");

                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
