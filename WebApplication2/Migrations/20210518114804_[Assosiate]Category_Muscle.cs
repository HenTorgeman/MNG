using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class AssosiateCategory_Muscle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                table: "Muscles",
                newName: "categoryId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hebrewName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_categoryId",
                table: "Muscles",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_Category_categoryId",
                table: "Muscles",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
            //Changed from  Cascade to NoAction by Hen Torgeman on 18/05/21
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muscles_Category_categoryId",
                table: "Muscles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Muscles_categoryId",
                table: "Muscles");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Muscles",
                newName: "category");
        }
    }
}
