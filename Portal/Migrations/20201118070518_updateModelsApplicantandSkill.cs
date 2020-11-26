using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class updateModelsApplicantandSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_ApplicantSkill");

            migrationBuilder.CreateTable(
                name: "ApplicantSkill",
                columns: table => new
                {
                    ApplicantsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantSkill", x => new { x.ApplicantsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ApplicantSkill_TB_M_Applicant_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "TB_M_Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantSkill_TB_M_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "TB_M_Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantSkill_SkillsId",
                table: "ApplicantSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantSkill");

            migrationBuilder.CreateTable(
                name: "TB_T_ApplicantSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_ApplicantSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_ApplicantSkill_TB_M_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "TB_M_Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_ApplicantSkill_TB_M_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "TB_M_Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_ApplicantSkill_ApplicantId",
                table: "TB_T_ApplicantSkill",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_ApplicantSkill_SkillId",
                table: "TB_T_ApplicantSkill",
                column: "SkillId");
        }
    }
}
