using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Add_Prepormence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainee_Review_reviewid",
                table: "Exercise_Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Review_reviewid",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Review_reviewid",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Preformence");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preformence",
                table: "Preformence",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainee_Preformence_reviewid",
                table: "Exercise_Trainee",
                column: "reviewid",
                principalTable: "Preformence",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Preformence_reviewid",
                table: "Training",
                column: "reviewid",
                principalTable: "Preformence",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Preformence_reviewid",
                table: "User",
                column: "reviewid",
                principalTable: "Preformence",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainee_Preformence_reviewid",
                table: "Exercise_Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Preformence_reviewid",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Preformence_reviewid",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preformence",
                table: "Preformence");

            migrationBuilder.RenameTable(
                name: "Preformence",
                newName: "Review");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainee_Review_reviewid",
                table: "Exercise_Trainee",
                column: "reviewid",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Review_reviewid",
                table: "Training",
                column: "reviewid",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Review_reviewid",
                table: "User",
                column: "reviewid",
                principalTable: "Review",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
