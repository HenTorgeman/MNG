using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Rename_Muscle_Property2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleid",
                table: "Exercise_Muscle");

            migrationBuilder.DropColumn(
                name: "musclesId",
                table: "Exercise_Muscle");

            migrationBuilder.RenameColumn(
                name: "muscleid",
                table: "Exercise_Muscle",
                newName: "muscleId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_Muscle_muscleid",
                table: "Exercise_Muscle",
                newName: "IX_Exercise_Muscle_muscleId");

            migrationBuilder.AlterColumn<int>(
                name: "muscleId",
                table: "Exercise_Muscle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleId",
                table: "Exercise_Muscle",
                column: "muscleId",
                principalTable: "Muscles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleId",
                table: "Exercise_Muscle");

            migrationBuilder.RenameColumn(
                name: "muscleId",
                table: "Exercise_Muscle",
                newName: "muscleid");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_Muscle_muscleId",
                table: "Exercise_Muscle",
                newName: "IX_Exercise_Muscle_muscleid");

            migrationBuilder.AlterColumn<int>(
                name: "muscleid",
                table: "Exercise_Muscle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "musclesId",
                table: "Exercise_Muscle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Muscle_Muscles_muscleid",
                table: "Exercise_Muscle",
                column: "muscleid",
                principalTable: "Muscles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
