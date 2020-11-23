using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "TB_T_UnivDept");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "TB_T_UnivDept",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TB_M_Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "TB_T_UnivDept");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "TB_T_UnivDept",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
