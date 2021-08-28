using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAppWebApi.Data.Migrations
{
    public partial class birthinsurancedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceDate",
                table: "Insurees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "Insurees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceDate",
                table: "Insurees");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "Insurees");
        }
    }
}
