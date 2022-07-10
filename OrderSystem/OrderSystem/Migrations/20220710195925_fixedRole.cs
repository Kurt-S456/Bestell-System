using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class fixedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerShi_RoRoles_RoleRoId",
                table: "PerShi");

            migrationBuilder.DropIndex(
                name: "IX_PerShi_RoleRoId",
                table: "PerShi");

            migrationBuilder.DropColumn(
                name: "RoleRoId",
                table: "PerShi");

            migrationBuilder.RenameColumn(
                name: "RoId",
                table: "PerShi",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PerShi_RoleId",
                table: "PerShi",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerShi_RoRoles_RoleId",
                table: "PerShi",
                column: "RoleId",
                principalTable: "RoRoles",
                principalColumn: "RoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerShi_RoRoles_RoleId",
                table: "PerShi");

            migrationBuilder.DropIndex(
                name: "IX_PerShi_RoleId",
                table: "PerShi");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "PerShi",
                newName: "RoId");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleRoId",
                table: "PerShi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerShi_RoleRoId",
                table: "PerShi",
                column: "RoleRoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerShi_RoRoles_RoleRoId",
                table: "PerShi",
                column: "RoleRoId",
                principalTable: "RoRoles",
                principalColumn: "RoId");
        }
    }
}
