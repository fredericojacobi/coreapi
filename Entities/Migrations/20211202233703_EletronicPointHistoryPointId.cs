using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class EletronicPointHistoryPointId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "EletronicPointHistories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PointId",
                table: "EletronicPointHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EletronicPointHistories_PointId",
                table: "EletronicPointHistories",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EletronicPointHistories_Points_PointId",
                table: "EletronicPointHistories",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_EletronicPointHistories_Points_PointId",
                table: "EletronicPointHistories");

            migrationBuilder.DropIndex(
                name: "IX_EletronicPointHistories_PointId",
                table: "EletronicPointHistories");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "EletronicPointHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "EletronicPointHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EletronicPointHistories_Locations_LocationId",
                table: "EletronicPointHistories",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
