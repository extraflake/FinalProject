using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class deleteTableRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_ExamDetail_TB_M_Record_RecordId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropTable(
                name: "TB_M_Record");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_ExamDetail_RecordId",
                table: "TB_M_ExamDetail");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "TB_M_ExamDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "TB_M_ExamDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoRecord = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Record", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_ExamDetail_RecordId",
                table: "TB_M_ExamDetail",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_ExamDetail_TB_M_Record_RecordId",
                table: "TB_M_ExamDetail",
                column: "RecordId",
                principalTable: "TB_M_Record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
