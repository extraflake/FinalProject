using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class addmodelapplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPA",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduateYear",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Majors",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "TB_M_Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "GraduateYear",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Majors",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "University",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
