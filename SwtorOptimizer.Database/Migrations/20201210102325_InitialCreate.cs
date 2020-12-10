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
                name: "GearPieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endurance = table.Column<int>(nullable: false),
                    Mastery = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    Tertiary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearPieces", x => x.Id);
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
                name: "GearSets",
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
                    table.PrimaryKey("PK_GearSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSets_CalculationTasks_CalculationTaskId",
                        column: x => x.CalculationTaskId,
                        principalTable: "CalculationTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearSetGearPieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearPieceId = table.Column<int>(nullable: false),
                    GearSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearSetGearPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSetGearPieces_GearPieces_GearPieceId",
                        column: x => x.GearPieceId,
                        principalTable: "GearPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearSetGearPieces_GearSets_GearSetId",
                        column: x => x.GearSetId,
                        principalTable: "GearSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GearSetGearPieces_GearPieceId",
                table: "GearSetGearPieces",
                column: "GearPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSetGearPieces_GearSetId",
                table: "GearSetGearPieces",
                column: "GearSetId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSets_CalculationTaskId",
                table: "GearSets",
                column: "CalculationTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearSetGearPieces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GearPieces");

            migrationBuilder.DropTable(
                name: "GearSets");

            migrationBuilder.DropTable(
                name: "CalculationTasks");
        }
    }
}
