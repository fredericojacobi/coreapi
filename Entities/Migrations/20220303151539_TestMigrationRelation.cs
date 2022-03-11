using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class TestMigrationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestClassTestStudent",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestClassTestStudent", x => new { x.ClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_TestClassTestStudent_TestClasses_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "TestClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestClassTestStudent_TestStudents_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "TestStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRelations_TestClasses_TestClassId",
                        column: x => x.TestClassId,
                        principalTable: "TestClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestRelations_TestStudents_TestStudentId",
                        column: x => x.TestStudentId,
                        principalTable: "TestStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestClassTestStudent_StudentsId",
                table: "TestClassTestStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRelations_TestClassId",
                table: "TestRelations",
                column: "TestClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRelations_TestStudentId",
                table: "TestRelations",
                column: "TestStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestClassTestStudent");

            migrationBuilder.DropTable(
                name: "TestRelations");

            migrationBuilder.DropTable(
                name: "TestClasses");

            migrationBuilder.DropTable(
                name: "TestStudents");
        }
    }
}
