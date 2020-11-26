using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class add1to1relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_ExamDetail_DurationId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_ExamDetail_GradeId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Duration_ScheduleId",
                table: "TB_M_Duration");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_DurationId",
                table: "TB_M_ExamDetail",
                column: "DurationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_GradeId",
                table: "TB_M_ExamDetail",
                column: "GradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Duration_ScheduleId",
                table: "TB_M_Duration",
                column: "ScheduleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_ExamDetail_DurationId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_ExamDetail_GradeId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Duration_ScheduleId",
                table: "TB_M_Duration");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_DurationId",
                table: "TB_M_ExamDetail",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_GradeId",
                table: "TB_M_ExamDetail",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Duration_ScheduleId",
                table: "TB_M_Duration",
                column: "ScheduleId");
        }
    }
}
