using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bingo_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    badge_file = table.Column<string>(type: "text", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    total_subtasks = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("achievements_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("scanobjects_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    required_points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("level_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    radius = table.Column<int>(type: "integer", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("locations_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usr",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usr_pk", x => x.id);
                    table.ForeignKey(
                        name: "usr_level",
                        column: x => x.level_id,
                        principalTable: "level",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subtask",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    achievement_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    total_number = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<string>(type: "text", nullable: true),
                    location_id = table.Column<string>(type: "text", nullable: true),
                    image_file = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("subtask_pk", x => x.id);
                    table.ForeignKey(
                        name: "subtask_achievement",
                        column: x => x.achievement_id,
                        principalTable: "achievement",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "subtask_item",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "subtask_location",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_achievement",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    achievement_id = table.Column<int>(type: "integer", nullable: false),
                    completed_subtasks = table.Column<int>(type: "integer", nullable: false),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_achievement_pk", x => x.id);
                    table.ForeignKey(
                        name: "usr_ach_achievement",
                        column: x => x.achievement_id,
                        principalTable: "achievement",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "usr_ach_usr",
                        column: x => x.user_id,
                        principalTable: "usr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_item",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    item_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_item_pk", x => x.id);
                    table.ForeignKey(
                        name: "usr_item_item",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "usr_item_usr",
                        column: x => x.user_id,
                        principalTable: "usr",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_subtask",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_achievement_id = table.Column<string>(type: "text", nullable: false),
                    subtask_id = table.Column<string>(type: "text", nullable: false),
                    number_completed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_subtask_pk", x => x.id);
                    table.ForeignKey(
                        name: "usr_sub_subtask",
                        column: x => x.subtask_id,
                        principalTable: "subtask",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "usr_sub_usr_ach",
                        column: x => x.user_achievement_id,
                        principalTable: "user_achievement",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_subtask_achievement_id",
                table: "subtask",
                column: "achievement_id");

            migrationBuilder.CreateIndex(
                name: "IX_subtask_item_id",
                table: "subtask",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_subtask_location_id",
                table: "subtask",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_achievement_id",
                table: "user_achievement",
                column: "achievement_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_user_id",
                table: "user_achievement",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_item_item_id",
                table: "user_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_item_user_id",
                table: "user_item",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_subtask_subtask_id",
                table: "user_subtask",
                column: "subtask_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_subtask_user_achievement_id",
                table: "user_subtask",
                column: "user_achievement_id");

            migrationBuilder.CreateIndex(
                name: "IX_usr_level_id",
                table: "usr",
                column: "level_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_item");

            migrationBuilder.DropTable(
                name: "user_subtask");

            migrationBuilder.DropTable(
                name: "subtask");

            migrationBuilder.DropTable(
                name: "user_achievement");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "achievement");

            migrationBuilder.DropTable(
                name: "usr");

            migrationBuilder.DropTable(
                name: "level");
        }
    }
}
