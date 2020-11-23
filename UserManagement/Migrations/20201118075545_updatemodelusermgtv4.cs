using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee",
                column: "ReligionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ReligionID",
                table: "TB_M_Employee",
                column: "ReligionID",
                unique: true);
        }
    }
}
