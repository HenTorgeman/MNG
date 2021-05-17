using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Rename_Muscle_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_Muscles_musclesId",
                table: "Exercise_Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Muscle_musclesId",
                table: "Exercise_Muscle");

            migrationBuilder.AddColumn<int>(
                name: "muscleid",
                table: "Exercise_Muscle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Muscle_muscleid",
                table: "Exercise_Muscle",
                column: "muscleid");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleid",
                table: "Exercise_Muscle",
                column: "muscleid",
                principalTable: "Muscles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleid",
                table: "Exercise_Muscle");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Muscle_muscleid",
                table: "Exercise_Muscle");

            migrationBuilder.DropColumn(
                name: "muscleid",
                table: "Exercise_Muscle");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Muscle_musclesId",
                table: "Exercise_Muscle",
                column: "musclesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_Muscles_musclesId",
                table: "Exercise_Muscle",
                column: "musclesId",
                principalTable: "Muscles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
