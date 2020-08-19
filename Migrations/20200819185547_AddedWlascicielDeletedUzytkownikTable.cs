using Microsoft.EntityFrameworkCore.Migrations;

namespace GokartyProjekt.Migrations
{
    public partial class AddedWlascicielDeletedUzytkownikTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUzytkownik",
                table: "Pracownicy");

            migrationBuilder.DropColumn(
                name: "IdUzytkownik",
                table: "Kierowcy");

            migrationBuilder.AddColumn<int>(
                name: "IdWlasciciel",
                table: "Tory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Wlasciciel",
                columns: table => new
                {
                    IdWlasciciel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wlasciciel", x => x.IdWlasciciel);
                });

            migrationBuilder.InsertData(
                table: "Wlasciciel",
                columns: new[] { "IdWlasciciel", "Imie", "Nazwisko" },
                values: new object[] { 1, "Max", "Verstappen" });

            migrationBuilder.InsertData(
                table: "Wlasciciel",
                columns: new[] { "IdWlasciciel", "Imie", "Nazwisko" },
                values: new object[] { 2, "Stoffel", "Vandoorne" });

            migrationBuilder.InsertData(
                table: "Wlasciciel",
                columns: new[] { "IdWlasciciel", "Imie", "Nazwisko" },
                values: new object[] { 3, "Antonio", "Giovinazzi" });

            migrationBuilder.UpdateData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 1,
                column: "IdWlasciciel",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 2,
                column: "IdWlasciciel",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 3,
                column: "IdWlasciciel",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory",
                column: "IdWlasciciel",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tory_Wlasciciel_IdWlasciciel",
                table: "Tory",
                column: "IdWlasciciel",
                principalTable: "Wlasciciel",
                principalColumn: "IdWlasciciel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tory_Wlasciciel_IdWlasciciel",
                table: "Tory");

            migrationBuilder.DropTable(
                name: "Wlasciciel");

            migrationBuilder.DropIndex(
                name: "IX_Tory_IdWlasciciel",
                table: "Tory");

            migrationBuilder.DropColumn(
                name: "IdWlasciciel",
                table: "Tory");

            migrationBuilder.AddColumn<int>(
                name: "IdUzytkownik",
                table: "Pracownicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUzytkownik",
                table: "Kierowcy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
