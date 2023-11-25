using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Adoptame.Migrations
{
    public partial class FKcreations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FundationID",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PetID",
                table: "AdoptionDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FundationID",
                table: "Pets",
                column: "FundationID");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserID",
                table: "Pets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionDetails_PetID",
                table: "AdoptionDetails",
                column: "PetID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionDetails_Pets_PetID",
                table: "AdoptionDetails",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "IDpet",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Fundations_FundationID",
                table: "Pets",
                column: "FundationID",
                principalTable: "Fundations",
                principalColumn: "IDfundation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_UserID",
                table: "Pets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "IDuser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionDetails_Pets_PetID",
                table: "AdoptionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Fundations_FundationID",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_UserID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_FundationID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionDetails_PetID",
                table: "AdoptionDetails");

            migrationBuilder.DropColumn(
                name: "FundationID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetID",
                table: "AdoptionDetails");
        }
    }
}
