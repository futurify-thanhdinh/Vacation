using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileService.Migrations
{
    public partial class ChangeEmployeeListFKTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId1",
                table: "Employees",
                column: "TeamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamId1",
                table: "Employees",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeamId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "Employees");
        }
    }
}
