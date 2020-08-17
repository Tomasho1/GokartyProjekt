using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GokartyProjekt.Migrations
{
    public partial class SettingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    IdAdres = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Panstwo = table.Column<string>(maxLength: 50, nullable: false),
                    Miasto = table.Column<string>(maxLength: 50, nullable: false),
                    Ulica = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.IdAdres);
                });

            migrationBuilder.CreateTable(
                name: "Nadwozia",
                columns: table => new
                {
                    IdNadwozie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nadwozia", x => x.IdNadwozie);
                });

            migrationBuilder.CreateTable(
                name: "Podwozia",
                columns: table => new
                {
                    IdPodwozie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podwozia", x => x.IdPodwozie);
                });

            migrationBuilder.CreateTable(
                name: "Silniki",
                columns: table => new
                {
                    IdSilnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moc = table.Column<int>(nullable: false),
                    Pojemnosc = table.Column<double>(nullable: false),
                    Producent = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silniki", x => x.IdSilnik);
                });

            migrationBuilder.CreateTable(
                name: "Sponsorzy",
                columns: table => new
                {
                    IdSponsor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorzy", x => x.IdSponsor);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    IdUzytkownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 30, nullable: true),
                    Haslo = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.IdUzytkownik);
                });

            migrationBuilder.CreateTable(
                name: "Tory",
                columns: table => new
                {
                    IdTor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<int>(maxLength: 50, nullable: false),
                    Dlugosc = table.Column<double>(nullable: false),
                    StawkaGodzinowa = table.Column<decimal>(type: "money", nullable: false),
                    IdAdres = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tory", x => x.IdTor);
                    table.ForeignKey(
                        name: "FK_Tory_Adresy_IdAdres",
                        column: x => x.IdAdres,
                        principalTable: "Adresy",
                        principalColumn: "IdAdres",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kierowcy",
                columns: table => new
                {
                    IdKierowca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Wiek = table.Column<int>(nullable: false),
                    NumerKarty = table.Column<string>(maxLength: 20, nullable: false),
                    IdUzytkownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierowcy", x => x.IdKierowca);
                    table.ForeignKey(
                        name: "FK_Kierowcy_Uzytkownicy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Gokarty",
                columns: table => new
                {
                    IdGokart = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Waga = table.Column<int>(nullable: false),
                    IdSilnik = table.Column<int>(nullable: false),
                    IdPodwozie = table.Column<int>(nullable: false),
                    IdNadwozie = table.Column<int>(nullable: false),
                    IdTor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gokarty", x => x.IdGokart);
                    table.ForeignKey(
                        name: "FK_Gokarty_Nadwozia_IdNadwozie",
                        column: x => x.IdNadwozie,
                        principalTable: "Nadwozia",
                        principalColumn: "IdNadwozie",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Gokarty_Podwozia_IdPodwozie",
                        column: x => x.IdPodwozie,
                        principalTable: "Podwozia",
                        principalColumn: "IdPodwozie",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Gokarty_Silniki_IdSilnik",
                        column: x => x.IdSilnik,
                        principalTable: "Silniki",
                        principalColumn: "IdSilnik",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Gokarty_Tory_IdTor",
                        column: x => x.IdTor,
                        principalTable: "Tory",
                        principalColumn: "IdTor",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Wiek = table.Column<int>(nullable: false),
                    Stanowisko = table.Column<string>(maxLength: 50, nullable: false),
                    Wynagrodzenie = table.Column<decimal>(type: "money", nullable: false),
                    IdTor = table.Column<int>(nullable: false),
                    IdUzytkownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Tory_IdTor",
                        column: x => x.IdTor,
                        principalTable: "Tory",
                        principalColumn: "IdTor",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Uzytkownicy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KierowcaSponsor",
                columns: table => new
                {
                    IdKierowca = table.Column<int>(nullable: false),
                    IdSponsor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KierowcaSponsor", x => new { x.IdKierowca, x.IdSponsor });
                    table.ForeignKey(
                        name: "FK_KierowcaSponsor_Kierowcy_IdKierowca",
                        column: x => x.IdKierowca,
                        principalTable: "Kierowcy",
                        principalColumn: "IdKierowca",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KierowcaSponsor_Sponsorzy_IdSponsor",
                        column: x => x.IdSponsor,
                        principalTable: "Sponsorzy",
                        principalColumn: "IdSponsor",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    IdSprzet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Koszt = table.Column<string>(nullable: true),
                    IdKierowca = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.IdSprzet);
                    table.ForeignKey(
                        name: "FK_Sprzety_Kierowcy_IdKierowca",
                        column: x => x.IdKierowca,
                        principalTable: "Kierowcy",
                        principalColumn: "IdKierowca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Przejazdy",
                columns: table => new
                {
                    IdPrzejazd = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czas = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdTor = table.Column<int>(nullable: false),
                    IdGokart = table.Column<int>(nullable: false),
                    IdKierowca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przejazdy", x => x.IdPrzejazd);
                    table.ForeignKey(
                        name: "FK_Przejazdy_Gokarty_IdGokart",
                        column: x => x.IdGokart,
                        principalTable: "Gokarty",
                        principalColumn: "IdGokart",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Przejazdy_Kierowcy_IdKierowca",
                        column: x => x.IdKierowca,
                        principalTable: "Kierowcy",
                        principalColumn: "IdKierowca",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Przejazdy_Tory_IdTor",
                        column: x => x.IdTor,
                        principalTable: "Tory",
                        principalColumn: "IdTor",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gokarty_IdNadwozie",
                table: "Gokarty",
                column: "IdNadwozie");

            migrationBuilder.CreateIndex(
                name: "IX_Gokarty_IdPodwozie",
                table: "Gokarty",
                column: "IdPodwozie");

            migrationBuilder.CreateIndex(
                name: "IX_Gokarty_IdSilnik",
                table: "Gokarty",
                column: "IdSilnik");

            migrationBuilder.CreateIndex(
                name: "IX_Gokarty_IdTor",
                table: "Gokarty",
                column: "IdTor");

            migrationBuilder.CreateIndex(
                name: "IX_KierowcaSponsor_IdSponsor",
                table: "KierowcaSponsor",
                column: "IdSponsor");

            migrationBuilder.CreateIndex(
                name: "IX_Kierowcy_IdUzytkownik",
                table: "Kierowcy",
                column: "IdUzytkownik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_IdTor",
                table: "Pracownicy",
                column: "IdTor");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_IdUzytkownik",
                table: "Pracownicy",
                column: "IdUzytkownik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Przejazdy_IdGokart",
                table: "Przejazdy",
                column: "IdGokart");

            migrationBuilder.CreateIndex(
                name: "IX_Przejazdy_IdKierowca",
                table: "Przejazdy",
                column: "IdKierowca");

            migrationBuilder.CreateIndex(
                name: "IX_Przejazdy_IdTor",
                table: "Przejazdy",
                column: "IdTor");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzety_IdKierowca",
                table: "Sprzety",
                column: "IdKierowca");

            migrationBuilder.CreateIndex(
                name: "IX_Tory_IdAdres",
                table: "Tory",
                column: "IdAdres",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KierowcaSponsor");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Przejazdy");

            migrationBuilder.DropTable(
                name: "Sprzety");

            migrationBuilder.DropTable(
                name: "Sponsorzy");

            migrationBuilder.DropTable(
                name: "Gokarty");

            migrationBuilder.DropTable(
                name: "Kierowcy");

            migrationBuilder.DropTable(
                name: "Nadwozia");

            migrationBuilder.DropTable(
                name: "Podwozia");

            migrationBuilder.DropTable(
                name: "Silniki");

            migrationBuilder.DropTable(
                name: "Tory");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Adresy");
        }
    }
}
