using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "TB_T_UnivDept");

            migrationBuilder.DropColumn(
                name: "UnivID",
                table: "TB_T_UnivDept");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeptID",
                table: "TB_T_UnivDept",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnivID",
                table: "TB_T_UnivDept",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
