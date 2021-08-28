using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAppWebApi.Data.Migrations
{
    public partial class manytomanysimple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurees", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceInsuree");

            migrationBuilder.DropTable(
                name: "Insurees");
        }
    }
}
