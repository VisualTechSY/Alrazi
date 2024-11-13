using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class addTestPortage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTest");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "TestSubjectResult");

            migrationBuilder.DropTable(
                name: "TestSubject");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.CreateTable(
                name: "TestPortages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Examiner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attendant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPortages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPortages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestStanfordBinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Examiner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStanfordBinets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestStanfordBinets_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestPortageDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPortageId = table.Column<int>(type: "int", nullable: false),
                    TestPortageSubject = table.Column<int>(type: "int", nullable: false),
                    AgeTheBase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeAddonal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGrowth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPortageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPortageDetails_TestPortages_TestPortageId",
                        column: x => x.TestPortageId,
                        principalTable: "TestPortages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestStanfordBinetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestStanfordBinetId = table.Column<int>(type: "int", nullable: false),
                    TestStanfordBinetSubject = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    PercentileRank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStanfordBinetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestStanfordBinetDetails_TestStanfordBinets_TestStanfordBinetId",
                        column: x => x.TestStanfordBinetId,
                        principalTable: "TestStanfordBinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestPortageDetails_TestPortageId",
                table: "TestPortageDetails",
                column: "TestPortageId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPortages_StudentId",
                table: "TestPortages",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TestStanfordBinetDetails_TestStanfordBinetId",
                table: "TestStanfordBinetDetails",
                column: "TestStanfordBinetId");

            migrationBuilder.CreateIndex(
                name: "IX_TestStanfordBinets_StudentId",
                table: "TestStanfordBinets",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestPortageDetails");

            migrationBuilder.DropTable(
                name: "TestStanfordBinetDetails");

            migrationBuilder.DropTable(
                name: "TestPortages");

            migrationBuilder.DropTable(
                name: "TestStanfordBinets");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResult_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSubject_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TestSubjectId = table.Column<int>(type: "int", nullable: false),
                    Additional = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheBase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTest_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTest_TestSubject_TestSubjectId",
                        column: x => x.TestSubjectId,
                        principalTable: "TestSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSubjectResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestSubjectId = table.Column<int>(type: "int", nullable: false),
                    AgeOfMounth = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSubjectResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSubjectResult_TestSubject_TestSubjectId",
                        column: x => x.TestSubjectId,
                        principalTable: "TestSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_StudentId",
                table: "StudentTest",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_TestSubjectId",
                table: "StudentTest",
                column: "TestSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_TestId",
                table: "TestResult",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubject_TestId",
                table: "TestSubject",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubjectResult_TestSubjectId",
                table: "TestSubjectResult",
                column: "TestSubjectId");
        }
    }
}
