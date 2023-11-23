using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bingo_api.Migrations
{
    /// <inheritdoc />
    public partial class IdentityIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "badge",
                columns: table => new
                {
                    badgeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imageurl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("badges_pk", x => x.badgeid);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    levelnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    requiredpoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("levels_pk", x => x.levelnumber);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    locationid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<decimal>(type: "numeric(10,8)", precision: 10, scale: 8, nullable: false),
                    longitude = table.Column<decimal>(type: "numeric(11,8)", precision: 11, scale: 8, nullable: false),
                    radius = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("locations_pk", x => x.locationid);
                });

            migrationBuilder.CreateTable(
                name: "timely",
                columns: table => new
                {
                    timelyid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    starttime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("timely_pk", x => x.timelyid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    levelnumber = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "users_levels",
                        column: x => x.levelnumber,
                        principalTable: "level",
                        principalColumn: "levelnumber");
                });

            migrationBuilder.CreateTable(
                name: "scantype",
                columns: table => new
                {
                    scantypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    locationid = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("scanobjects_pk", x => x.scantypeid);
                    table.ForeignKey(
                        name: "scanobjects_locations",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "locationid");
                });

            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    achievementid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    badgeid = table.Column<int>(type: "integer", nullable: true),
                    timelyid = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("achievements_pk", x => x.achievementid);
                    table.ForeignKey(
                        name: "achievements_timely",
                        column: x => x.timelyid,
                        principalTable: "timely",
                        principalColumn: "timelyid");
                    table.ForeignKey(
                        name: "fk_0",
                        column: x => x.badgeid,
                        principalTable: "badge",
                        principalColumn: "badgeid");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quickplayobject",
                columns: table => new
                {
                    quickplayobjectid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scantypeid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quickplayobject_pk", x => x.quickplayobjectid);
                    table.ForeignKey(
                        name: "quickplay_scanobjects",
                        column: x => x.scantypeid,
                        principalTable: "scantype",
                        principalColumn: "scantypeid");
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    taskid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    achievementid = table.Column<int>(type: "integer", nullable: false),
                    scantypeid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("achievementtasks_pk", x => x.taskid);
                    table.ForeignKey(
                        name: "fk_1",
                        column: x => x.achievementid,
                        principalTable: "achievement",
                        principalColumn: "achievementid");
                    table.ForeignKey(
                        name: "fk_2",
                        column: x => x.scantypeid,
                        principalTable: "scantype",
                        principalColumn: "scantypeid");
                });

            migrationBuilder.CreateTable(
                name: "userachievement",
                columns: table => new
                {
                    userachievementid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    achievementid = table.Column<int>(type: "integer", nullable: false),
                    dateearned = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userachievements_pk", x => x.userachievementid);
                    table.ForeignKey(
                        name: "fk_3",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "userachievements_achievements",
                        column: x => x.achievementid,
                        principalTable: "achievement",
                        principalColumn: "achievementid");
                });

            migrationBuilder.CreateTable(
                name: "quickplay",
                columns: table => new
                {
                    quickplayid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quickplayobjectid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    lastrefreshdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    scandate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userquickplay_pk", x => x.quickplayid);
                    table.ForeignKey(
                        name: "userquickplay_quickplay",
                        column: x => x.quickplayobjectid,
                        principalTable: "quickplayobject",
                        principalColumn: "quickplayobjectid");
                    table.ForeignKey(
                        name: "userquickplay_users",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "usertask",
                columns: table => new
                {
                    usertaskid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    taskid = table.Column<int>(type: "integer", nullable: false),
                    datecompleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    quantitycompleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usertask_pk", x => x.usertaskid);
                    table.ForeignKey(
                        name: "user_achievement_tasks_achievementtasks",
                        column: x => x.taskid,
                        principalTable: "task",
                        principalColumn: "taskid");
                    table.ForeignKey(
                        name: "user_achievement_tasks_users",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievement_badgeid",
                table: "achievement",
                column: "badgeid");

            migrationBuilder.CreateIndex(
                name: "IX_achievement_timelyid",
                table: "achievement",
                column: "timelyid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_quickplay_quickplayobjectid",
                table: "quickplay",
                column: "quickplayobjectid");

            migrationBuilder.CreateIndex(
                name: "IX_quickplay_userid",
                table: "quickplay",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_quickplayobject_scantypeid",
                table: "quickplayobject",
                column: "scantypeid");

            migrationBuilder.CreateIndex(
                name: "IX_scantype_locationid",
                table: "scantype",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "IX_task_achievementid",
                table: "task",
                column: "achievementid");

            migrationBuilder.CreateIndex(
                name: "IX_task_scantypeid",
                table: "task",
                column: "scantypeid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_user_levelnumber",
                table: "user",
                column: "levelnumber");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userachievement_achievementid",
                table: "userachievement",
                column: "achievementid");

            migrationBuilder.CreateIndex(
                name: "IX_userachievement_userid",
                table: "userachievement",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_usertask_taskid",
                table: "usertask",
                column: "taskid");

            migrationBuilder.CreateIndex(
                name: "IX_usertask_userid",
                table: "usertask",
                column: "userid");

            migrationBuilder.Sql(
            "-- START --\n\n-- Badge\nINSERT INTO Badge VALUES (default, 'http://example.com/badge1.png');\nINSERT INTO Badge VALUES (default, 'http://example.com/badge2.png');\n\n-- Levels\nINSERT INTO \"level\" VALUES (default, 100);\nINSERT INTO \"level\" VALUES (default, 200);\nINSERT INTO \"level\" VALUES (default, 300);\nINSERT INTO \"level\" VALUES (default, 400);\nINSERT INTO \"level\" VALUES (default, 500);\n\n-- Location\nINSERT INTO \"location\" (LocationID, Name, Latitude, Longitude, Radius) VALUES (default, 'Location 1', 34.052235, -118.243683, 5.00);\nINSERT INTO \"location\" (LocationID, Name, Latitude, Longitude, Radius) VALUES (default, 'Location 2', 40.730610, -73.935242, 3.50);\n\n-- ScanType\nINSERT INTO ScanType (ScanTypeID, LocationID, Name, Description) VALUES (default, 1, 'Scan 1', 'Description for Scan 1');\nINSERT INTO ScanType (ScanTypeID, LocationID, Name, Description) VALUES (default, 2, 'Scan 2', 'Description for Scan 2');\n\n-- Timely\nINSERT INTO Timely (TimelyID, StartTime, EndTime, Description) VALUES (default, '2023-09-25', '2023-09-30', 'Timely event for this week');\n\n-- Achievement\nINSERT INTO Achievement (AchievementID, BadgeID, TimelyID, Name, Points) VALUES (default, 1, 1, 'Achievement 1', 10);\nINSERT INTO Achievement (AchievementID, BadgeID, Name, Points) VALUES (default, 2, 'Achievement 2', 20);\n\n-- Task\nINSERT INTO Task (TaskID, AchievementID, ScanTypeID, Description, Quantity) VALUES (default, 1, 1, 'Task related to Achievement 1 and Scan 1', 5);\nINSERT INTO Task (TaskID, AchievementID, ScanTypeID, Description, Quantity) VALUES (default, 2, 2, 'Task related to Achievement 2 and Scan 2', 3);\n\n-- QuickplayObject\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 1, 'Object 1', 10);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 2, 'Object 2', 15);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 1, 'Ballon', 20);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 2, 'Tiger', 40);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 1, 'Pigeon', 30);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 2, 'Motorcycle', 30);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 1, 'Sushi', 50);\nINSERT INTO QuickplayObject (QuickplayObjectID, ScanTypeID, Name, Points) VALUES (default, 2, 'Tennis Ball', 40);"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "quickplay");

            migrationBuilder.DropTable(
                name: "userachievement");

            migrationBuilder.DropTable(
                name: "usertask");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "quickplayobject");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "achievement");

            migrationBuilder.DropTable(
                name: "scantype");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "timely");

            migrationBuilder.DropTable(
                name: "badge");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
