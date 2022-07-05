using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class relationsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_RoRoles_PerRoleRoId",
                table: "PerPersons");

            migrationBuilder.DropIndex(
                name: "IX_PerPersons_PerRoleRoId",
                table: "PerPersons");

            migrationBuilder.DropColumn(
                name: "PerRoleRoId",
                table: "PerPersons");

            migrationBuilder.RenameColumn(
                name: "PerId",
                table: "UsrUsers",
                newName: "PerPersonId");

            migrationBuilder.RenameColumn(
                name: "RoId",
                table: "PerPersons",
                newName: "RoRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_RoRoleId",
                table: "PerPersons",
                column: "RoRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_RoRoles_RoRoleId",
                table: "PerPersons",
                column: "RoRoleId",
                principalTable: "RoRoles",
                principalColumn: "RoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_RoRoles_RoRoleId",
                table: "PerPersons");

            migrationBuilder.DropIndex(
                name: "IX_PerPersons_RoRoleId",
                table: "PerPersons");

            migrationBuilder.RenameColumn(
                name: "PerPersonId",
                table: "UsrUsers",
                newName: "PerId");

            migrationBuilder.RenameColumn(
                name: "RoRoleId",
                table: "PerPersons",
                newName: "RoId");

            migrationBuilder.AddColumn<Guid>(
                name: "PerRoleRoId",
                table: "PerPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_PerRoleRoId",
                table: "PerPersons",
                column: "PerRoleRoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_RoRoles_PerRoleRoId",
                table: "PerPersons",
                column: "PerRoleRoId",
                principalTable: "RoRoles",
                principalColumn: "RoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
