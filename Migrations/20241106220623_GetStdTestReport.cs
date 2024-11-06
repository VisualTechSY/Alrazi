using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class GetStdTestReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberCorrectAnswers",
                table: "StudentTest",
                newName: "Additional");

            migrationBuilder.AddColumn<double>(
                name: "TheBase",
                table: "StudentTest",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheBase",
                table: "StudentTest");

            migrationBuilder.RenameColumn(
                name: "Additional",
                table: "StudentTest",
                newName: "NumberCorrectAnswers");
        }
    }
}
