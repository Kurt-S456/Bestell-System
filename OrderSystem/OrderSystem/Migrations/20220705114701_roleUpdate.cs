using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class roleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "RoRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isStaff",
                table: "RoRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "RoRoles");

            migrationBuilder.DropColumn(
                name: "isStaff",
                table: "RoRoles");
        }
    }
}
