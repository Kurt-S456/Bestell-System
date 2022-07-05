using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class UserRelationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons");

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                principalTable: "UsrUsers",
                principalColumn: "UsrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons");

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                principalTable: "UsrUsers",
                principalColumn: "UsrId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
