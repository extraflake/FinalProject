using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class updateModelApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyCheck",
                table: "TB_M_Applicant",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyCheck",
                table: "TB_M_Applicant");
        }
    }
}
