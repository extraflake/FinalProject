using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Academic",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "City",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "TB_M_Applicant");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "TB_M_Applicant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "TB_M_Applicant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_M_Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Reference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_ApplicantSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_ApplicantSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_ApplicantSkill_TB_M_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "TB_M_Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_ApplicantSkill_TB_M_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "TB_M_Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicant_PositionId",
                table: "TB_M_Applicant",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicant_ReferenceId",
                table: "TB_M_Applicant",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_ApplicantSkill_ApplicantId",
                table: "TB_T_ApplicantSkill",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_ApplicantSkill_SkillId",
                table: "TB_T_ApplicantSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Position_PositionId",
                table: "TB_M_Applicant",
                column: "PositionId",
                principalTable: "TB_M_Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Reference_ReferenceId",
                table: "TB_M_Applicant",
                column: "ReferenceId",
                principalTable: "TB_M_Reference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Position_PositionId",
                table: "TB_M_Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicant_TB_M_Reference_ReferenceId",
                table: "TB_M_Applicant");

            migrationBuilder.DropTable(
                name: "TB_M_Position");

            migrationBuilder.DropTable(
                name: "TB_M_Reference");

            migrationBuilder.DropTable(
                name: "TB_T_ApplicantSkill");

            migrationBuilder.DropTable(
                name: "TB_M_Skill");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicant_PositionId",
                table: "TB_M_Applicant");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicant_ReferenceId",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "TB_M_Applicant");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "TB_M_Applicant");

            migrationBuilder.AddColumn<string>(
                name: "Academic",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "TB_M_Applicant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPA",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduationYear",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
