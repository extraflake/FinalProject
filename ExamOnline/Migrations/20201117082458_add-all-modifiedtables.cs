using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class addallmodifiedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Score");

            migrationBuilder.DropTable(
                name: "TB_M_Applicant");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TB_M_Segment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionQuantity",
                table: "TB_M_Segment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "TB_M_Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Grades = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Duration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Duration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Duration_TB_M_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "TB_M_Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_ExamDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalScore = table.Column<int>(type: "int", nullable: false),
                    DurationId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_ExamDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_ExamDetail_TB_M_Duration_DurationId",
                        column: x => x.DurationId,
                        principalTable: "TB_M_Duration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_ExamDetail_TB_M_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "TB_M_Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Duration_ScheduleId",
                table: "TB_M_Duration",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_DurationId",
                table: "TB_M_ExamDetail",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_GradeId",
                table: "TB_M_ExamDetail",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_ExamDetail");

            migrationBuilder.DropTable(
                name: "TB_M_Duration");

            migrationBuilder.DropTable(
                name: "TB_M_Grade");

            migrationBuilder.DropTable(
                name: "TB_M_Schedule");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TB_M_Segment");

            migrationBuilder.DropColumn(
                name: "QuestionQuantity",
                table: "TB_M_Segment");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "TB_M_Question");

            migrationBuilder.CreateTable(
                name: "TB_M_Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    FinalScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Score_TB_M_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "TB_M_Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Score_ApplicantId",
                table: "TB_M_Score",
                column: "ApplicantId");
        }
    }
}
