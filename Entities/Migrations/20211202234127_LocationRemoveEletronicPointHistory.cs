using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class LocationRemoveEletronicPointHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories");

            migrationBuilder.DropIndex(
                name: "IX_EletronicPointHistories_LocationId",
                table: "EletronicPointHistories");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "EletronicPointHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "EletronicPointHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EletronicPointHistories_LocationId",
                table: "EletronicPointHistories",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
