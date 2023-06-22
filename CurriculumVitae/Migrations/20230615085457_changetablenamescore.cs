using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitae.Migrations
{
    public partial class changetablenamescore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamScore",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralExam = table.Column<float>(type: "real", nullable: false),
                    FifteenMinScore = table.Column<float>(type: "real", nullable: false),
                    MidtermExam = table.Column<float>(type: "real", nullable: false),
                    FinalExam = table.Column<float>(type: "real", nullable: false),
                    ToltalScore = table.Column<float>(type: "real", nullable: false),
                    ReviewAndEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicReview = table.Column<int>(type: "int", nullable: false),
                    ConductComments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamScore", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamScore");
        }
    }
}
