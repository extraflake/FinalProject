using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_EducationId",
                table: "TB_M_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_UnivDept_TB_M_Department_DepartmentId",
                table: "TB_T_UnivDept");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_UnivDept_TB_M_University_UniversityId",
                table: "TB_T_UnivDept");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_UnivDept",
                table: "TB_T_UnivDept");

            migrationBuilder.RenameTable(
                name: "TB_T_UnivDept",
                newName: "TB_T_Education");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_UnivDept_UniversityId",
                table: "TB_T_Education",
                newName: "IX_TB_T_Education_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_UnivDept_DepartmentId",
                table: "TB_T_Education",
                newName: "IX_TB_T_Education_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Education",
                table: "TB_T_Education",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_T_Education_EducationId",
                table: "TB_M_Employee",
                column: "EducationId",
                principalTable: "TB_T_Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Education_TB_M_Department_DepartmentId",
                table: "TB_T_Education",
                column: "DepartmentId",
                principalTable: "TB_M_Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Education_TB_M_University_UniversityId",
                table: "TB_T_Education",
                column: "UniversityId",
                principalTable: "TB_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_T_Education_EducationId",
                table: "TB_M_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Education_TB_M_Department_DepartmentId",
                table: "TB_T_Education");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Education_TB_M_University_UniversityId",
                table: "TB_T_Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Education",
                table: "TB_T_Education");

            migrationBuilder.RenameTable(
                name: "TB_T_Education",
                newName: "TB_T_UnivDept");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Education_UniversityId",
                table: "TB_T_UnivDept",
                newName: "IX_TB_T_UnivDept_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_Education_DepartmentId",
                table: "TB_T_UnivDept",
                newName: "IX_TB_T_UnivDept_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_UnivDept",
                table: "TB_T_UnivDept",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_EducationId",
                table: "TB_M_Employee",
                column: "EducationId",
                principalTable: "TB_T_UnivDept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_UnivDept_TB_M_Department_DepartmentId",
                table: "TB_T_UnivDept",
                column: "DepartmentId",
                principalTable: "TB_M_Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_UnivDept_TB_M_University_UniversityId",
                table: "TB_T_UnivDept",
                column: "UniversityId",
                principalTable: "TB_M_University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
