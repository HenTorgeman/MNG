using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Rename_Muscle_ExeecisesMuscle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "MusclesTraining_Program");

            migrationBuilder.CreateTable(
                name: "Exercise_Muscle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    musclesId = table.Column<int>(type: "int", nullable: false),
                    exerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Muscle", x => x.id);
                    table.ForeignKey(
                        name: "FK_Exercise_Muscle_Exercise_exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Muscle_Muscles_musclesId",
                        column: x => x.musclesId,
                        principalTable: "Muscles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuscleTraining_Program",
                columns: table => new
                {
                    musclesid = table.Column<int>(type: "int", nullable: false),
                    training_Programsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleTraining_Program", x => new { x.musclesid, x.training_Programsid });
                    table.ForeignKey(
                        name: "FK_MuscleTraining_Program_Muscles_musclesid",
                        column: x => x.musclesid,
                        principalTable: "Muscles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleTraining_Program_Training_Program_training_Programsid",
                        column: x => x.training_Programsid,
                        principalTable: "Training_Program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Muscle_exerciseId",
                table: "Exercise_Muscle",
                column: "exerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Muscle_musclesId",
                table: "Exercise_Muscle",
                column: "musclesId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleTraining_Program_training_Programsid",
                table: "MuscleTraining_Program",
                column: "training_Programsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise_Muscle");

            migrationBuilder.DropTable(
                name: "MuscleTraining_Program");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exerciseId = table.Column<int>(type: "int", nullable: false),
                    musclesId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscles", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Exercise_exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Muscles_musclesId",
                        column: x => x.musclesId,
                        principalTable: "Muscles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusclesTraining_Program",
                columns: table => new
                {
                    musclesid = table.Column<int>(type: "int", nullable: false),
                    training_Programsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusclesTraining_Program", x => new { x.musclesid, x.training_Programsid });
                    table.ForeignKey(
                        name: "FK_MusclesTraining_Program_Muscles_musclesid",
                        column: x => x.musclesid,
                        principalTable: "Muscles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusclesTraining_Program_Training_Program_training_Programsid",
                        column: x => x.training_Programsid,
                        principalTable: "Training_Program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_exerciseId",
                table: "ExerciseMuscles",
                column: "exerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_musclesId",
                table: "ExerciseMuscles",
                column: "musclesId");

            migrationBuilder.CreateIndex(
                name: "IX_MusclesTraining_Program_training_Programsid",
                table: "MusclesTraining_Program",
                column: "training_Programsid");
        }
    }
}
