using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Adoptame.Migrations
{
    public partial class Other : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FundationID",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FundationID",
                table: "Pets",
                column: "FundationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Fundations_FundationID",
                table: "Pets",
                column: "FundationID",
                principalTable: "Fundations",
                principalColumn: "IDfundation",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Fundations_FundationID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_FundationID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "FundationID",
                table: "Pets");
        }
    }
}
