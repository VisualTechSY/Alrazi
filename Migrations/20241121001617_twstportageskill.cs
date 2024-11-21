using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class twstportageskill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestPortageSkill_TestPortages_TestPortageId",
                table: "TestPortageSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestPortageSkill",
                table: "TestPortageSkill");

            migrationBuilder.RenameTable(
                name: "TestPortageSkill",
                newName: "TestPortageSkills");

            migrationBuilder.RenameIndex(
                name: "IX_TestPortageSkill_TestPortageId",
                table: "TestPortageSkills",
                newName: "IX_TestPortageSkills_TestPortageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestPortageSkills",
                table: "TestPortageSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestPortageSkills_TestPortages_TestPortageId",
                table: "TestPortageSkills",
                column: "TestPortageId",
                principalTable: "TestPortages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestPortageSkills_TestPortages_TestPortageId",
                table: "TestPortageSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestPortageSkills",
                table: "TestPortageSkills");

            migrationBuilder.RenameTable(
                name: "TestPortageSkills",
                newName: "TestPortageSkill");

            migrationBuilder.RenameIndex(
                name: "IX_TestPortageSkills_TestPortageId",
                table: "TestPortageSkill",
                newName: "IX_TestPortageSkill_TestPortageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestPortageSkill",
                table: "TestPortageSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestPortageSkill_TestPortages_TestPortageId",
                table: "TestPortageSkill",
                column: "TestPortageId",
                principalTable: "TestPortages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
