using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnivId",
                table: "TB_T_UnivDept",
                newName: "UnivID");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "TB_T_UnivDept",
                newName: "DeptID");

            migrationBuilder.AlterColumn<string>(
                name: "UnivID",
                table: "TB_T_UnivDept",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DeptID",
                table: "TB_T_UnivDept",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnivID",
                table: "TB_T_UnivDept",
                newName: "UnivId");

            migrationBuilder.RenameColumn(
                name: "DeptID",
                table: "TB_T_UnivDept",
                newName: "DeptId");

            migrationBuilder.AlterColumn<int>(
                name: "UnivId",
                table: "TB_T_UnivDept",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeptId",
                table: "TB_T_UnivDept",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
