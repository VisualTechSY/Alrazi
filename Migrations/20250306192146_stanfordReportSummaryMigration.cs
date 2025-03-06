using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class stanfordReportSummaryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "TestStanfordBinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendations",
                table: "TestStanfordBinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "TestStanfordBinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "TestStanfordBinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PercentileRank",
                table: "TestStanfordBinetDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "TestStanfordBinets");

            migrationBuilder.DropColumn(
                name: "Recommendations",
                table: "TestStanfordBinets");

            migrationBuilder.DropColumn(
                name: "School",
                table: "TestStanfordBinets");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "TestStanfordBinets");

            migrationBuilder.AlterColumn<int>(
                name: "PercentileRank",
                table: "TestStanfordBinetDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
