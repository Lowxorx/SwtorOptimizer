using Microsoft.EntityFrameworkCore.Migrations;

namespace SwtorOptimizer.Database.Migrations
{
    public partial class GearStat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GearPieceStat",
                table: "GearPieces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearPieceStat",
                table: "GearPieces");
        }
    }
}
