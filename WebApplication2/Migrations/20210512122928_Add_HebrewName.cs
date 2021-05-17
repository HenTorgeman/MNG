using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Add_HebrewName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HebrewName",
                table: "Muscles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HebrewName",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HebrewName",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "HebrewName",
                table: "Exercise");
        }
    }
}
