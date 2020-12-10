using Microsoft.EntityFrameworkCore.Migrations;

namespace SwtorOptimizer.Database.Migrations
{
    public partial class GearType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GearPieceType",
                table: "GearPieces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearPieceType",
                table: "GearPieces");
        }
    }
}
