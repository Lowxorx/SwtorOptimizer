using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwtorOptimizer.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FoundSets = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Threshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enhancements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccuracyName = table.Column<string>(nullable: true),
                    AlacrityName = table.Column<string>(nullable: true),
                    CriticalName = table.Column<string>(nullable: true),
                    Endurance = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    Tertiary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enhancements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnhancementSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculationTaskId = table.Column<int>(nullable: false),
                    IsInvalid = table.Column<bool>(nullable: false),
                    SetInternalName = table.Column<string>(nullable: true),
                    SetName = table.Column<string>(nullable: true),
                    Threshold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnhancementSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnhancementSets_CalculationTasks_CalculationTaskId",
                        column: x => x.CalculationTaskId,
                        principalTable: "CalculationTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnhancementSetEnhancements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnhancementId = table.Column<int>(nullable: false),
                    EnhancementSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnhancementSetEnhancements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnhancementSetEnhancements_Enhancements_EnhancementId",
                        column: x => x.EnhancementId,
                        principalTable: "Enhancements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnhancementSetEnhancements_EnhancementSets_EnhancementSetId",
                        column: x => x.EnhancementSetId,
                        principalTable: "EnhancementSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnhancementSetEnhancements_EnhancementId",
                table: "EnhancementSetEnhancements",
                column: "EnhancementId");

            migrationBuilder.CreateIndex(
                name: "IX_EnhancementSetEnhancements_EnhancementSetId",
                table: "EnhancementSetEnhancements",
                column: "EnhancementSetId");

            migrationBuilder.CreateIndex(
                name: "IX_EnhancementSets_CalculationTaskId",
                table: "EnhancementSets",
                column: "CalculationTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnhancementSetEnhancements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Enhancements");

            migrationBuilder.DropTable(
                name: "EnhancementSets");

            migrationBuilder.DropTable(
                name: "CalculationTasks");
        }
    }
}
