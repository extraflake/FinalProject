using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatemodelusermgtv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TB_M_User",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "TB_M_Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_User_Username",
                table: "TB_M_User",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_Phone",
                table: "TB_M_Employee",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_M_User_Username",
                table: "TB_M_User");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Employee_Phone",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TB_M_User");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "TB_M_Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
