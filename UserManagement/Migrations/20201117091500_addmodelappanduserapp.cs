using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class addmodelappanduserapp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_UserApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_UserApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_UserApplication_TB_M_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "TB_M_Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_UserApplication_TB_M_User_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UserApplication_ApplicationId",
                table: "TB_T_UserApplication",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UserApplication_UserId",
                table: "TB_T_UserApplication",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_UserApplication");

            migrationBuilder.DropTable(
                name: "TB_M_Application");
        }
    }
}
