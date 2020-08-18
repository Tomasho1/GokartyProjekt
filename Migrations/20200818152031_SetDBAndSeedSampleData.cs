using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GokartyProjekt.Migrations
{
    public partial class SetDBAndSeedSampleData : Migration
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
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
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
                        principalColumn: "IdAdres");
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
                        principalColumn: "IdUzytkownik");
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
                        principalColumn: "IdNadwozie");
                    table.ForeignKey(
                        name: "FK_Gokarty_Podwozia_IdPodwozie",
                        column: x => x.IdPodwozie,
                        principalTable: "Podwozia",
                        principalColumn: "IdPodwozie");
                    table.ForeignKey(
                        name: "FK_Gokarty_Silniki_IdSilnik",
                        column: x => x.IdSilnik,
                        principalTable: "Silniki",
                        principalColumn: "IdSilnik");
                    table.ForeignKey(
                        name: "FK_Gokarty_Tory_IdTor",
                        column: x => x.IdTor,
                        principalTable: "Tory",
                        principalColumn: "IdTor");
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
                        principalColumn: "IdTor");
                    table.ForeignKey(
                        name: "FK_Pracownicy_Uzytkownicy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "IdUzytkownik");
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
                        principalColumn: "IdKierowca");
                    table.ForeignKey(
                        name: "FK_KierowcaSponsor_Sponsorzy_IdSponsor",
                        column: x => x.IdSponsor,
                        principalTable: "Sponsorzy",
                        principalColumn: "IdSponsor");
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    IdSprzet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Koszt = table.Column<double>(nullable: false),
                    IdKierowca = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.IdSprzet);
                    table.ForeignKey(
                        name: "FK_Sprzety_Kierowcy_IdKierowca",
                        column: x => x.IdKierowca,
                        principalTable: "Kierowcy",
                        principalColumn: "IdKierowca");
                });

            migrationBuilder.CreateTable(
                name: "Przejazdy",
                columns: table => new
                {
                    IdPrzejazd = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czas = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataPrzejazdu = table.Column<DateTime>(type: "datetime", nullable: false),
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
                        principalColumn: "IdGokart");
                    table.ForeignKey(
                        name: "FK_Przejazdy_Kierowcy_IdKierowca",
                        column: x => x.IdKierowca,
                        principalTable: "Kierowcy",
                        principalColumn: "IdKierowca");
                    table.ForeignKey(
                        name: "FK_Przejazdy_Tory_IdTor",
                        column: x => x.IdTor,
                        principalTable: "Tory",
                        principalColumn: "IdTor");
                });

            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "IdAdres", "Miasto", "Panstwo", "Ulica" },
                values: new object[,]
                {
                    { 1, "Monza", "Włochy", "Viale di Vedano, 5" },
                    { 2, "Stavelot", "Belgia", "Route du Circuit 55" },
                    { 3, "Zandvoort", "Holandia", "Burgemeester van Alphenstraat 108" }
                });

            migrationBuilder.InsertData(
                table: "Nadwozia",
                columns: new[] { "IdNadwozie", "Producent" },
                values: new object[,]
                {
                    { 1, "Alfa Romeo" },
                    { 2, "Honda" },
                    { 3, "Chevrolet" }
                });

            migrationBuilder.InsertData(
                table: "Podwozia",
                columns: new[] { "IdPodwozie", "Producent" },
                values: new object[,]
                {
                    { 1, "Alfa Romeo" },
                    { 2, "Honda" },
                    { 3, "Chevrolet" }
                });

            migrationBuilder.InsertData(
                table: "Silniki",
                columns: new[] { "IdSilnik", "Moc", "Pojemnosc", "Producent" },
                values: new object[,]
                {
                    { 3, 25, 800.0, "Ferrari" },
                    { 2, 15, 350.0, "Audi" },
                    { 1, 20, 600.0, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Sponsorzy",
                columns: new[] { "IdSponsor", "Nazwa" },
                values: new object[,]
                {
                    { 1, "ORLEN" },
                    { 2, "STS" },
                    { 3, "PEKAO" }
                });

            migrationBuilder.InsertData(
                table: "Sprzety",
                columns: new[] { "IdSprzet", "IdKierowca", "Koszt", "Nazwa" },
                values: new object[] { 2, null, 15.0, "Rękawice czarne normalne" });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "IdUzytkownik", "Haslo", "Login" },
                values: new object[,]
                {
                    { 1, "kowalski12", "tkowalski" },
                    { 2, "pedziwiatr2016", "mpedzi" },
                    { 3, "mazurek", "jmazur" },
                    { 4, "wojcik95", "pwojcik" },
                    { 5, "walczakxd", "rwalczak" },
                    { 6, "krzysiekblyskawica", "krzysiu44" }
                });

            migrationBuilder.InsertData(
                table: "Kierowcy",
                columns: new[] { "IdKierowca", "IdUzytkownik", "Imie", "Nazwisko", "NumerKarty", "Wiek" },
                values: new object[,]
                {
                    { 1, 1, "Tomasz", "Kowalski", "k1704", 21 },
                    { 2, 2, "Marcin", "Pędziwiatr", "k898", 16 },
                    { 3, 3, "Jakub", "Mazur", "k19", 18 }
                });

            migrationBuilder.InsertData(
                table: "Tory",
                columns: new[] { "IdTor", "Dlugosc", "IdAdres", "Nazwa", "StawkaGodzinowa" },
                values: new object[,]
                {
                    { 1, 5.7930000000000001, 1, "Autodromo Nazionale di Monza", 400m },
                    { 2, 7.0039999999999996, 2, "Circuit de Spa-Francorchamps", 450m },
                    { 3, 4.2519999999999998, 3, "Circuit Zandvoort", 350m }
                });

            migrationBuilder.InsertData(
                table: "Gokarty",
                columns: new[] { "IdGokart", "IdNadwozie", "IdPodwozie", "IdSilnik", "IdTor", "Nazwa", "Waga" },
                values: new object[,]
                {
                    { 2, 1, 1, 1, 1, "Standard", 160 },
                    { 3, 3, 3, 3, 2, "Standard+", 180 },
                    { 1, 2, 2, 2, 3, "Junior", 150 }
                });

            migrationBuilder.InsertData(
                table: "KierowcaSponsor",
                columns: new[] { "IdKierowca", "IdSponsor" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdTor", "IdUzytkownik", "Imie", "Nazwisko", "Stanowisko", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { 1, 1, 1, "Paweł", "Wójcik", "Recepcjonista", 25, 3300m },
                    { 2, 2, 2, "Robert", "Walczak", "Instruktor", 31, 4500m },
                    { 3, 3, 3, "Krzysztof", "Błyskawica", "Kierownik toru", 28, 5500m }
                });

            migrationBuilder.InsertData(
                table: "Sprzety",
                columns: new[] { "IdSprzet", "IdKierowca", "Koszt", "Nazwa" },
                values: new object[,]
                {
                    { 1, 1, 25.0, "Kask czerwony mały" },
                    { 3, 3, 10.0, "Kominiarka normalna" }
                });

            migrationBuilder.InsertData(
                table: "Przejazdy",
                columns: new[] { "IdPrzejazd", "Czas", "DataPrzejazdu", "IdGokart", "IdKierowca", "IdTor" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 4, 25, 732), new DateTime(2020, 6, 18, 11, 33, 47, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 2, new TimeSpan(0, 0, 4, 27, 319), new DateTime(2019, 12, 20, 17, 2, 13, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 3, new TimeSpan(0, 0, 4, 25, 588), new DateTime(2019, 10, 13, 16, 45, 38, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 4, new TimeSpan(0, 0, 3, 59, 711), new DateTime(2020, 7, 18, 14, 7, 16, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 5, new TimeSpan(0, 0, 3, 59, 646), new DateTime(2020, 7, 18, 14, 12, 29, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 6, new TimeSpan(0, 0, 4, 2, 11), new DateTime(2018, 10, 23, 20, 0, 36, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 7, new TimeSpan(0, 0, 5, 38, 412), new DateTime(2019, 8, 30, 15, 56, 4, 0, DateTimeKind.Unspecified), 3, 3, 2 },
                    { 8, new TimeSpan(0, 0, 5, 41, 774), new DateTime(2019, 9, 16, 9, 14, 36, 0, DateTimeKind.Unspecified), 3, 3, 2 },
                    { 9, new TimeSpan(0, 0, 5, 37, 292), new DateTime(2020, 8, 17, 12, 37, 40, 0, DateTimeKind.Unspecified), 3, 3, 2 }
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
