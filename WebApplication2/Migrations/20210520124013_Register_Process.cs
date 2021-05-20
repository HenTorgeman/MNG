using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Register_Process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "Training_Program",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "trainings_duration",
                table: "Training_Program",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "img_name",
                table: "Performance",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "Training_Program");

            migrationBuilder.DropColumn(
                name: "trainings_duration",
                table: "Training_Program");

            migrationBuilder.DropColumn(
                name: "img_name",
                table: "Performance");
        }
    }
}
