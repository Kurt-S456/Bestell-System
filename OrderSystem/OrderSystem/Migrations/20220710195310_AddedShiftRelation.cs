using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class AddedShiftRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdOrders_PerPersons_PerPersonPerId",
                table: "OrdOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdOrders_UsrUsers_UsrUserUsrId",
                table: "OrdOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_RoRoles_RoRoleId",
                table: "PerPersons");

            migrationBuilder.DropIndex(
                name: "IX_PerPersons_RoRoleId",
                table: "PerPersons");

            migrationBuilder.DropIndex(
                name: "IX_OrdOrders_PerPersonPerId",
                table: "OrdOrders");

            migrationBuilder.DropColumn(
                name: "RoRoleId",
                table: "PerPersons");

            migrationBuilder.DropColumn(
                name: "PerPersonPerId",
                table: "OrdOrders");

            migrationBuilder.RenameColumn(
                name: "UsrUserUsrId",
                table: "OrdOrders",
                newName: "ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdOrders_UsrUserUsrId",
                table: "OrdOrders",
                newName: "IX_OrdOrders_ShiftId");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonPerId",
                table: "OrdOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrders_PersonPerId",
                table: "OrdOrders",
                column: "PersonPerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdOrders_PerPersons_PersonPerId",
                table: "OrdOrders",
                column: "PersonPerId",
                principalTable: "PerPersons",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdOrders_ShiShifts_ShiftId",
                table: "OrdOrders",
                column: "ShiftId",
                principalTable: "ShiShifts",
                principalColumn: "ShiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdOrders_PerPersons_PersonPerId",
                table: "OrdOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdOrders_ShiShifts_ShiftId",
                table: "OrdOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrdOrders_PersonPerId",
                table: "OrdOrders");

            migrationBuilder.DropColumn(
                name: "PersonPerId",
                table: "OrdOrders");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "OrdOrders",
                newName: "UsrUserUsrId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdOrders_ShiftId",
                table: "OrdOrders",
                newName: "IX_OrdOrders_UsrUserUsrId");

            migrationBuilder.AddColumn<Guid>(
                name: "RoRoleId",
                table: "PerPersons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PerPersonPerId",
                table: "OrdOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_RoRoleId",
                table: "PerPersons",
                column: "RoRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrders_PerPersonPerId",
                table: "OrdOrders",
                column: "PerPersonPerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdOrders_PerPersons_PerPersonPerId",
                table: "OrdOrders",
                column: "PerPersonPerId",
                principalTable: "PerPersons",
                principalColumn: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdOrders_UsrUsers_UsrUserUsrId",
                table: "OrdOrders",
                column: "UsrUserUsrId",
                principalTable: "UsrUsers",
                principalColumn: "UsrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_RoRoles_RoRoleId",
                table: "PerPersons",
                column: "RoRoleId",
                principalTable: "RoRoles",
                principalColumn: "RoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
