using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class fixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotherAgeAtBirth",
                table: "StudentFamilyInfos");

            migrationBuilder.RenameColumn(
                name: "IsNatural",
                table: "StudentMotherMedicals",
                newName: "IsBlue");

            migrationBuilder.AddColumn<string>(
                name: "SkillsFamilyRequiredChild",
                table: "StudentNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComplicationsDuringPregnancy",
                table: "StudentMotherMedicals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "BirthType",
                table: "StudentMotherMedicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MotherAgeAtBirth",
                table: "StudentMotherMedicals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AFewCompareColleagues",
                table: "StudentMistakes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AlotCompareColleagues",
                table: "StudentMistakes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EyeExaminationResult",
                table: "StudentMedicalTests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BrainScanResult",
                table: "StudentMedicalTests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AudiogramTypeResult",
                table: "StudentMedicalTests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ChildResidence",
                table: "StudentFamilyInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillsFamilyRequiredChild",
                table: "StudentNotes");

            migrationBuilder.DropColumn(
                name: "BirthType",
                table: "StudentMotherMedicals");

            migrationBuilder.DropColumn(
                name: "MotherAgeAtBirth",
                table: "StudentMotherMedicals");

            migrationBuilder.DropColumn(
                name: "AFewCompareColleagues",
                table: "StudentMistakes");

            migrationBuilder.DropColumn(
                name: "AlotCompareColleagues",
                table: "StudentMistakes");

            migrationBuilder.RenameColumn(
                name: "IsBlue",
                table: "StudentMotherMedicals",
                newName: "IsNatural");

            migrationBuilder.AlterColumn<bool>(
                name: "ComplicationsDuringPregnancy",
                table: "StudentMotherMedicals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EyeExaminationResult",
                table: "StudentMedicalTests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrainScanResult",
                table: "StudentMedicalTests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AudiogramTypeResult",
                table: "StudentMedicalTests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ChildResidence",
                table: "StudentFamilyInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "MotherAgeAtBirth",
                table: "StudentFamilyInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
