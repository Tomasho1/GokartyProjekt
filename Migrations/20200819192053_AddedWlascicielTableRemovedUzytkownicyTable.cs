using Microsoft.EntityFrameworkCore.Migrations;

namespace GokartyProjekt.Migrations
{
    public partial class AddedWlascicielTableRemovedUzytkownicyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory");

            migrationBuilder.CreateIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory",
                column: "IdWlasciciel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory");

            migrationBuilder.CreateIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory",
                column: "IdWlasciciel",
                unique: true);
        }
    }
}
