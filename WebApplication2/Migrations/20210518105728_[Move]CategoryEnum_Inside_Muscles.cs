using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class MoveCategoryEnum_Inside_Muscles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_coachId",
                table: "Training");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_coachId",
                table: "Training",
                column: "coachId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
            //Changed from casada to No action by Hen Torgeman on 18/05/21
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_coachId",
                table: "Training");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_coachId",
                table: "Training",
                column: "coachId",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
