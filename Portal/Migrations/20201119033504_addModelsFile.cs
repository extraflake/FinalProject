using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class addModelsFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocPath",
                table: "TB_M_Applicant");

            migrationBuilder.CreateTable(
                name: "TB_M_Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Files_TB_M_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "TB_M_Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Files_ApplicantId",
                table: "TB_M_Files",
                column: "ApplicantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Files");

            migrationBuilder.AddColumn<string>(
                name: "DocPath",
                table: "TB_M_Applicant",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
