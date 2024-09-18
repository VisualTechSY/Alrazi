using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class addStudentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentStatus",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentStatus",
                table: "Students");
        }
    }
}
