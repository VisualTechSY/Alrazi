using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class addLDColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsQualified",
                table: "StudentAbilities");

            migrationBuilder.AddColumn<string>(
                name: "HealthStatus",
                table: "StudentSiblings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LaboratoryTests",
                table: "StudentMedicalTests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "GotJaundice",
                table: "StudentMedicals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherProplem",
                table: "StudentMedicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RhesusFactor",
                table: "StudentMedicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthStatus",
                table: "StudentSiblings");

            migrationBuilder.DropColumn(
                name: "GotJaundice",
                table: "StudentMedicals");

            migrationBuilder.DropColumn(
                name: "OtherProplem",
                table: "StudentMedicals");

            migrationBuilder.DropColumn(
                name: "RhesusFactor",
                table: "StudentMedicals");

            migrationBuilder.AlterColumn<string>(
                name: "LaboratoryTests",
                table: "StudentMedicalTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsQualified",
                table: "StudentAbilities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
