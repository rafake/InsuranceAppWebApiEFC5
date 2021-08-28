using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAppWebApi.Data.Migrations
{
    public partial class m2mpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceInsuree");

            migrationBuilder.CreateTable(
                name: "InsureeInsurance",
                columns: table => new
                {
                    InsureeId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsureeInsurance", x => new { x.InsuranceId, x.InsureeId });
                    table.ForeignKey(
                        name: "FK_InsureeInsurance_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsureeInsurance_Insurees_InsureeId",
                        column: x => x.InsureeId,
                        principalTable: "Insurees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsureeInsurance_InsureeId",
                table: "InsureeInsurance",
                column: "InsureeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsureeInsurance");

            migrationBuilder.CreateTable(
                name: "InsuranceInsuree",
                columns: table => new
                {
                    InsurancesId = table.Column<int>(type: "int", nullable: false),
                    InsureesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceInsuree", x => new { x.InsurancesId, x.InsureesId });
                    table.ForeignKey(
                        name: "FK_InsuranceInsuree_Insurances_InsurancesId",
                        column: x => x.InsurancesId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceInsuree_Insurees_InsureesId",
                        column: x => x.InsureesId,
                        principalTable: "Insurees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceInsuree_InsureesId",
                table: "InsuranceInsuree",
                column: "InsureesId");
        }
    }
}
