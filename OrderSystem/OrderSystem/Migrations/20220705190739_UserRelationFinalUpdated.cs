using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class UserRelationFinalUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons");

            migrationBuilder.DropIndex(
                name: "IX_PerPersons_UsrUserId",
                table: "PerPersons");

            migrationBuilder.AddForeignKey(
                name: "FK_UsrUsers_PerPersons_UsrId",
                table: "UsrUsers",
                column: "UsrId",
                principalTable: "PerPersons",
                principalColumn: "PerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsrUsers_PerPersons_UsrId",
                table: "UsrUsers");

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                principalTable: "UsrUsers",
                principalColumn: "UsrId");
        }
    }
}
