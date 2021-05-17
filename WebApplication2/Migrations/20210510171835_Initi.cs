using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalTrainerApp.Migrations
{
    public partial class Initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    max_whight = table.Column<double>(type: "float", nullable: false),
                    min_whight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainee_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coach_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trainee_score = table.Column<int>(type: "int", nullable: false),
                    coach_score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
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
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subscribe_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reviewid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Review_reviewid",
                        column: x => x.reviewid,
                        principalTable: "Review",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    traineeId = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Performance_User_traineeId",
                        column: x => x.traineeId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training_Program",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_Program", x => x.id);
                    table.ForeignKey(
                        name: "FK_Training_Program_User_traineeId",
                        column: x => x.traineeId,
                        principalTable: "User",
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

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    coachId = table.Column<int>(type: "int", nullable: false),
                    training_programId = table.Column<int>(type: "int", nullable: false),
                    scoreid = table.Column<int>(type: "int", nullable: true),
                    reviewid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.id);
                    table.ForeignKey(
                        name: "FK_Training_Review_reviewid",
                        column: x => x.reviewid,
                        principalTable: "Review",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_Score_scoreid",
                        column: x => x.scoreid,
                        principalTable: "Score",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_Training_Program_training_programId",
                        column: x => x.training_programId,
                        principalTable: "Training_Program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Training_User_coachId",
                        column: x => x.coachId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Trainee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exerciseId = table.Column<int>(type: "int", nullable: false),
                    trainingId = table.Column<int>(type: "int", nullable: false),
                    repets = table.Column<int>(type: "int", nullable: false),
                    max_wight = table.Column<double>(type: "float", nullable: false),
                    rpg = table.Column<double>(type: "float", nullable: false),
                    parameter1 = table.Column<double>(type: "float", nullable: false),
                    parameter2 = table.Column<double>(type: "float", nullable: false),
                    scoreid = table.Column<int>(type: "int", nullable: true),
                    reviewid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Trainee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainee_Exercise_exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainee_Review_reviewid",
                        column: x => x.reviewid,
                        principalTable: "Review",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainee_Score_scoreid",
                        column: x => x.scoreid,
                        principalTable: "Score",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainee_Training_trainingId",
                        column: x => x.trainingId,
                        principalTable: "Training",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainee_exerciseId",
                table: "Exercise_Trainee",
                column: "exerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainee_reviewid",
                table: "Exercise_Trainee",
                column: "reviewid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainee_scoreid",
                table: "Exercise_Trainee",
                column: "scoreid");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainee_trainingId",
                table: "Exercise_Trainee",
                column: "trainingId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Performance_traineeId",
                table: "Performance",
                column: "traineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_coachId",
                table: "Training",
                column: "coachId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_reviewid",
                table: "Training",
                column: "reviewid");

            migrationBuilder.CreateIndex(
                name: "IX_Training_scoreid",
                table: "Training",
                column: "scoreid");

            migrationBuilder.CreateIndex(
                name: "IX_Training_training_programId",
                table: "Training",
                column: "training_programId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_Program_traineeId",
                table: "Training_Program",
                column: "traineeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_reviewid",
                table: "User",
                column: "reviewid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise_Trainee");

            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "MusclesTraining_Program");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Training_Program");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
