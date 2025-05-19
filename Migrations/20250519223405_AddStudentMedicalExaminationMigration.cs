using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentMedicalExaminationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicalExamination",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalExamination",
                table: "Students");
        }
    }
}
