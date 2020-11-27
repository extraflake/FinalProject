using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class editTableRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraRecord",
                table: "TB_M_Record");

            migrationBuilder.RenameColumn(
                name: "MicRecord",
                table: "TB_M_Record",
                newName: "VideoRecord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoRecord",
                table: "TB_M_Record",
                newName: "MicRecord");

            migrationBuilder.AddColumn<byte[]>(
                name: "CameraRecord",
                table: "TB_M_Record",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
