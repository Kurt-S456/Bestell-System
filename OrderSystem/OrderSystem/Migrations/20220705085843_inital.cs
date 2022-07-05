using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EveEvents",
                columns: table => new
                {
                    EveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EveEvents", x => x.EveId);
                });

            migrationBuilder.CreateTable(
                name: "OStOrderStatuses",
                columns: table => new
                {
                    OStId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OStTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OStColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OStIsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OStOrderStatuses", x => x.OStId);
                });

            migrationBuilder.CreateTable(
                name: "ProProducts",
                columns: table => new
                {
                    ProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ProPriceBuy = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProProducts", x => x.ProId);
                });

            migrationBuilder.CreateTable(
                name: "RoRoles",
                columns: table => new
                {
                    RoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoRoles", x => x.RoId);
                });

            migrationBuilder.CreateTable(
                name: "StaStations",
                columns: table => new
                {
                    StaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaEveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaStations", x => x.StaId);
                    table.ForeignKey(
                        name: "FK_StaStations_EveEvents_StaEveId",
                        column: x => x.StaEveId,
                        principalTable: "EveEvents",
                        principalColumn: "EveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProProductStaStation",
                columns: table => new
                {
                    ProProductsProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaStationsStaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProProductStaStation", x => new { x.ProProductsProId, x.StaStationsStaId });
                    table.ForeignKey(
                        name: "FK_ProProductStaStation_ProProducts_ProProductsProId",
                        column: x => x.ProProductsProId,
                        principalTable: "ProProducts",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProProductStaStation_StaStations_StaStationsStaId",
                        column: x => x.StaStationsStaId,
                        principalTable: "StaStations",
                        principalColumn: "StaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdOrders",
                columns: table => new
                {
                    OrdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrUserUsrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OStStatusOStId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerPersonPerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdOrders", x => x.OrdId);
                    table.ForeignKey(
                        name: "FK_OrdOrders_OStOrderStatuses_OStStatusOStId",
                        column: x => x.OStStatusOStId,
                        principalTable: "OStOrderStatuses",
                        principalColumn: "OStId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProOrds",
                columns: table => new
                {
                    ProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProOrds", x => new { x.ProId, x.OrdId });
                    table.ForeignKey(
                        name: "FK_ProOrds_OrdOrders_OrdId",
                        column: x => x.OrdId,
                        principalTable: "OrdOrders",
                        principalColumn: "OrdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProOrds_ProProducts_ProId",
                        column: x => x.ProId,
                        principalTable: "ProProducts",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerPersons",
                columns: table => new
                {
                    PerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerRoleRoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerPersons", x => x.PerId);
                    table.ForeignKey(
                        name: "FK_PerPersons_RoRoles_PerRoleRoId",
                        column: x => x.PerRoleRoId,
                        principalTable: "RoRoles",
                        principalColumn: "RoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiShifts",
                columns: table => new
                {
                    ShiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiTitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiStaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerPersonPerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiShifts", x => x.ShiId);
                    table.ForeignKey(
                        name: "FK_ShiShifts_PerPersons_PerPersonPerId",
                        column: x => x.PerPersonPerId,
                        principalTable: "PerPersons",
                        principalColumn: "PerId");
                    table.ForeignKey(
                        name: "FK_ShiShifts_StaStations_ShiStaId",
                        column: x => x.ShiStaId,
                        principalTable: "StaStations",
                        principalColumn: "StaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsrUsers",
                columns: table => new
                {
                    UsrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsrUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiShiftShiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrUsers", x => x.UsrId);
                    table.ForeignKey(
                        name: "FK_UsrUsers_ShiShifts_ShiShiftShiId",
                        column: x => x.ShiShiftShiId,
                        principalTable: "ShiShifts",
                        principalColumn: "ShiId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrders_OStStatusOStId",
                table: "OrdOrders",
                column: "OStStatusOStId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrders_PerPersonPerId",
                table: "OrdOrders",
                column: "PerPersonPerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrders_UsrUserUsrId",
                table: "OrdOrders",
                column: "UsrUserUsrId");

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_PerRoleRoId",
                table: "PerPersons",
                column: "PerRoleRoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerPersons_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProOrds_OrdId",
                table: "ProOrds",
                column: "OrdId");

            migrationBuilder.CreateIndex(
                name: "IX_ProProductStaStation_StaStationsStaId",
                table: "ProProductStaStation",
                column: "StaStationsStaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiShifts_PerPersonPerId",
                table: "ShiShifts",
                column: "PerPersonPerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiShifts_ShiStaId",
                table: "ShiShifts",
                column: "ShiStaId");

            migrationBuilder.CreateIndex(
                name: "IX_StaStations_StaEveId",
                table: "StaStations",
                column: "StaEveId");

            migrationBuilder.CreateIndex(
                name: "IX_UsrUsers_ShiShiftShiId",
                table: "UsrUsers",
                column: "ShiShiftShiId");

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
                name: "FK_PerPersons_UsrUsers_UsrUserId",
                table: "PerPersons",
                column: "UsrUserId",
                principalTable: "UsrUsers",
                principalColumn: "UsrId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiShifts_PerPersons_PerPersonPerId",
                table: "ShiShifts");

            migrationBuilder.DropTable(
                name: "ProOrds");

            migrationBuilder.DropTable(
                name: "ProProductStaStation");

            migrationBuilder.DropTable(
                name: "OrdOrders");

            migrationBuilder.DropTable(
                name: "ProProducts");

            migrationBuilder.DropTable(
                name: "OStOrderStatuses");

            migrationBuilder.DropTable(
                name: "PerPersons");

            migrationBuilder.DropTable(
                name: "RoRoles");

            migrationBuilder.DropTable(
                name: "UsrUsers");

            migrationBuilder.DropTable(
                name: "ShiShifts");

            migrationBuilder.DropTable(
                name: "StaStations");

            migrationBuilder.DropTable(
                name: "EveEvents");
        }
    }
}
