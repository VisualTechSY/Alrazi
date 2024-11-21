using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class addTestPortageSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TestDateSkill",
                table: "TestPortages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TestPortageSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPortageId = table.Column<int>(type: "int", nullable: false),
                    TestPortage_Skill = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPortageSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPortageSkill_TestPortages_TestPortageId",
                        column: x => x.TestPortageId,
                        principalTable: "TestPortages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestPortageSkill_TestPortageId",
                table: "TestPortageSkill",
                column: "TestPortageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestPortageSkill");

            migrationBuilder.DropColumn(
                name: "TestDateSkill",
                table: "TestPortages");
        }
    }
}
