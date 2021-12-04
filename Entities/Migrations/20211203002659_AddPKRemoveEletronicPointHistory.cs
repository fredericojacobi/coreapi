using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddPKRemoveEletronicPointHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EletronicPointHistories",
                table: "EletronicPointHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EletronicPointHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EletronicPointHistories",
                table: "EletronicPointHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EletronicPointHistories_UserId",
                table: "EletronicPointHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EletronicPointHistories",
                table: "EletronicPointHistories");

            migrationBuilder.DropIndex(
                name: "IX_EletronicPointHistories_UserId",
                table: "EletronicPointHistories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EletronicPointHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EletronicPointHistories",
                table: "EletronicPointHistories",
                columns: new[] { "UserId", "PointId" });
        }
    }
}
