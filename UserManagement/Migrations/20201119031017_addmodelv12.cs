using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class addmodelv12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_Phone",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "TB_M_Employee");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "TB_M_User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_User_Phone",
                table: "TB_M_User",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_User_Phone",
                table: "TB_M_User");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "TB_M_User");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "TB_M_Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_Phone",
                table: "TB_M_Employee",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");
        }
    }
}
