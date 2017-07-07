using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileService.Migrations
{
    public partial class ChangeLeaderIdInTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_ID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_LeaderId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ID",
                table: "Teams",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_ID",
                table: "Teams",
                column: "ID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
