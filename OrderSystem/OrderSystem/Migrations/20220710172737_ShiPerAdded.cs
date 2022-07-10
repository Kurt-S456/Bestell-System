using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class ShiPerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiShifts_PerPersons_PerPersonPerId",
                table: "ShiShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsrUsers_PerPersons_UsrId",
                table: "UsrUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsrUsers_ShiShifts_ShiShiftShiId",
                table: "UsrUsers");

            migrationBuilder.DropIndex(
                name: "IX_UsrUsers_ShiShiftShiId",
                table: "UsrUsers");

            migrationBuilder.DropIndex(
                name: "IX_ShiShifts_PerPersonPerId",
                table: "ShiShifts");

            migrationBuilder.DropColumn(
                name: "PerPersonId",
                table: "UsrUsers");

            migrationBuilder.DropColumn(
                name: "ShiShiftShiId",
                table: "UsrUsers");

            migrationBuilder.DropColumn(
                name: "PerPersonPerId",
                table: "ShiShifts");

            migrationBuilder.DropColumn(
                name: "UsrUserId",
                table: "PerPersons");

            migrationBuilder.CreateTable(
                name: "PerShi",
                columns: table => new
                {
                    PerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleRoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerShi", x => new { x.PerId, x.ShiId });
                    table.ForeignKey(
                        name: "FK_PerShi_PerPersons_ShiId",
                        column: x => x.ShiId,
                        principalTable: "PerPersons",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerShi_RoRoles_RoleRoId",
                        column: x => x.RoleRoId,
                        principalTable: "RoRoles",
                        principalColumn: "RoId");
                    table.ForeignKey(
                        name: "FK_PerShi_ShiShifts_PerId",
                        column: x => x.PerId,
                        principalTable: "ShiShifts",
                        principalColumn: "ShiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerShi_RoleRoId",
                table: "PerShi",
                column: "RoleRoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerShi_ShiId",
                table: "PerShi",
                column: "ShiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerShi");

            migrationBuilder.AddColumn<Guid>(
                name: "PerPersonId",
                table: "UsrUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShiShiftShiId",
                table: "UsrUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PerPersonPerId",
                table: "ShiShifts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsrUserId",
                table: "PerPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UsrUsers_ShiShiftShiId",
                table: "UsrUsers",
                column: "ShiShiftShiId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiShifts_PerPersonPerId",
                table: "ShiShifts",
                column: "PerPersonPerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiShifts_PerPersons_PerPersonPerId",
                table: "ShiShifts",
                column: "PerPersonPerId",
                principalTable: "PerPersons",
                principalColumn: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsrUsers_PerPersons_UsrId",
                table: "UsrUsers",
                column: "UsrId",
                principalTable: "PerPersons",
                principalColumn: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsrUsers_ShiShifts_ShiShiftShiId",
                table: "UsrUsers",
                column: "ShiShiftShiId",
                principalTable: "ShiShifts",
                principalColumn: "ShiId");
        }
    }
}
