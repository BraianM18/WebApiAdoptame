using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Adoptame.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdoptionDetailId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PetID",
                table: "AdoptionDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionDetails_PetID",
                table: "AdoptionDetails",
                column: "PetID",
                unique: true,
                filter: "[PetID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionDetails_Pets_PetID",
                table: "AdoptionDetails",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "IDpet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionDetails_Pets_PetID",
                table: "AdoptionDetails");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionDetails_PetID",
                table: "AdoptionDetails");

            migrationBuilder.DropColumn(
                name: "AdoptionDetailId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetID",
                table: "AdoptionDetails");
        }
    }
}
