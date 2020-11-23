using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPA",
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

            migrationBuilder.AddColumn<int>(
                name: "ReligionID",
                table: "TB_M_Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnivDeptID",
                table: "TB_M_Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Religion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_University",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_University", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_UnivDept",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnivId = table.Column<int>(nullable: false),
                    UniversityId = table.Column<string>(nullable: true),
                    DeptId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    GPA = table.Column<string>(nullable: true),
                    GraduateYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_UnivDept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_UnivDept_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_UnivDept_TB_M_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "TB_M_University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee",
                column: "ReligionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_UnivDeptID",
                table: "TB_M_Employee",
                column: "UnivDeptID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UnivDept_DepartmentId",
                table: "TB_T_UnivDept",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UnivDept_UniversityId",
                table: "TB_T_UnivDept",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_M_Religion_ReligionID",
                table: "TB_M_Employee",
                column: "ReligionID",
                principalTable: "TB_M_Religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_UnivDeptID",
                table: "TB_M_Employee",
                column: "UnivDeptID",
                principalTable: "TB_T_UnivDept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_M_Religion_ReligionID",
                table: "TB_M_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Employee_TB_T_UnivDept_UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Religion");

            migrationBuilder.DropTable(
                name: "TB_T_UnivDept");

            migrationBuilder.DropTable(
                name: "TB_M_Department");

            migrationBuilder.DropTable(
                name: "TB_M_University");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "ReligionID",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "UnivDeptID",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "GPA",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduateYear",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Majors",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
