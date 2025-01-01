using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class TestPortageSkillDetalis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "TestPortageSkills");

            migrationBuilder.RenameColumn(
                name: "TestPortage_Skill",
                table: "TestPortageSkills",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "TestDateSkill",
                table: "TestPortages",
                newName: "LastTestDateSkill");

            migrationBuilder.AddColumn<DateTime>(
                name: "TestDateSkill",
                table: "TestPortageSkills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TestPortageSkillDetalis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPortageSkillId = table.Column<int>(type: "int", nullable: false),
                    TestPortage_Skill = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPortageSkillDetalis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPortageSkillDetalis_TestPortageSkills_TestPortageSkillId",
                        column: x => x.TestPortageSkillId,
                        principalTable: "TestPortageSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestPortageSkillDetalis_TestPortageSkillId",
                table: "TestPortageSkillDetalis",
                column: "TestPortageSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestPortageSkillDetalis");

            migrationBuilder.DropColumn(
                name: "TestDateSkill",
                table: "TestPortageSkills");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "TestPortageSkills",
                newName: "TestPortage_Skill");

            migrationBuilder.RenameColumn(
                name: "LastTestDateSkill",
                table: "TestPortages",
                newName: "TestDateSkill");

            migrationBuilder.AddColumn<double>(
                name: "Mark",
                table: "TestPortageSkills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
