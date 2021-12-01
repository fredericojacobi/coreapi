using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class ReminderLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Reminders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_LocationId",
                table: "Reminders",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Location_LocationId",
                table: "Reminders",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Location_LocationId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_LocationId",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Reminders");
        }
    }
}
