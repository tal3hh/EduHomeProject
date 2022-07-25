using Microsoft.EntityFrameworkCore.Migrations;

namespace ElmirProje.Migrations
{
    public partial class addTeacherSkillDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "TeacherSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "TeacherSkills");
        }
    }
}
