using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<int>(
                name: "EduID",
                table: "TB_M_Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_EducationId",
                table: "TB_M_Employee",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_EducationId",
                table: "TB_M_Employee",
                column: "EducationId",
                principalTable: "TB_T_UnivDept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_EducationId",
                table: "TB_M_Employee");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_EducationId",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "EduID",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<int>(
                name: "UnivDeptID",
                table: "TB_M_Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_UnivDeptID",
                table: "TB_M_Employee",
                column: "UnivDeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_UnivDeptID",
                table: "TB_M_Employee",
                column: "UnivDeptID",
                principalTable: "TB_T_UnivDept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
