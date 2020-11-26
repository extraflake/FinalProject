using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class updateModelApplicantFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Files_TB_M_Applicant_ApplicantId",
                table: "TB_M_Files");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Files_ApplicantId",
                table: "TB_M_Files");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "TB_M_Files");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "TB_M_Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicant_FileId",
                table: "TB_M_Applicant",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Files_FileId",
                table: "TB_M_Applicant",
                column: "FileId",
                principalTable: "TB_M_Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Files_FileId",
                table: "TB_M_Applicant");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicant_FileId",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "TB_M_Applicant");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "TB_M_Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Files_ApplicantId",
                table: "TB_M_Files",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Files_TB_M_Applicant_ApplicantId",
                table: "TB_M_Files",
                column: "ApplicantId",
                principalTable: "TB_M_Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
