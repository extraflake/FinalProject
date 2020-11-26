using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class updateModelsApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TB_M_Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TB_M_Applicant");
        }
    }
}
