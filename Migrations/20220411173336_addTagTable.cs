using Microsoft.EntityFrameworkCore.Migrations;

namespace ElmirProje.Migrations
{
    public partial class addTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacherSkills_Skills_SkillId",
                table: "teacherSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherSkills_Teachers_TeacherId",
                table: "teacherSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacherSkills",
                table: "teacherSkills");

            migrationBuilder.RenameTable(
                name: "teacherSkills",
                newName: "TeacherSkills");

            migrationBuilder.RenameIndex(
                name: "IX_teacherSkills_TeacherId",
                table: "TeacherSkills",
                newName: "IX_TeacherSkills_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_teacherSkills_SkillId_TeacherId",
                table: "TeacherSkills",
                newName: "IX_TeacherSkills_SkillId_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TagTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSkills_Teachers_TeacherId",
                table: "TeacherSkills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Skills_SkillId",
                table: "TeacherSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSkills_Teachers_TeacherId",
                table: "TeacherSkills");

            migrationBuilder.DropTable(
                name: "TagTables");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSkills",
                table: "TeacherSkills");

            migrationBuilder.RenameTable(
                name: "TeacherSkills",
                newName: "teacherSkills");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkills_TeacherId",
                table: "teacherSkills",
                newName: "IX_teacherSkills_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSkills_SkillId_TeacherId",
                table: "teacherSkills",
                newName: "IX_teacherSkills_SkillId_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacherSkills",
                table: "teacherSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_teacherSkills_Skills_SkillId",
                table: "teacherSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherSkills_Teachers_TeacherId",
                table: "teacherSkills",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
