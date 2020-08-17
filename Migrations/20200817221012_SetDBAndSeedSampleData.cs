using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GokartyProjekt.Migrations
{
    public partial class SetDBAndSeedSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Tory",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Koszt",
                table: "Sprzety",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "IdPrzejazd", "Czas", "IdGokart", "IdKierowca", "IdTor" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 4, 25, 732), 3, 1, 1 },
                    { 2, new TimeSpan(0, 0, 4, 27, 319), 3, 1, 1 },
                    { 3, new TimeSpan(0, 0, 4, 25, 588), 3, 1, 1 },
                    { 4, new TimeSpan(0, 0, 3, 59, 711), 3, 2, 3 },
                    { 5, new TimeSpan(0, 0, 3, 59, 646), 3, 2, 3 },
                    { 6, new TimeSpan(0, 0, 4, 2, 11), 3, 2, 3 },
                    { 7, new TimeSpan(0, 0, 5, 38, 412), 3, 3, 2 },
                    { 8, new TimeSpan(0, 0, 5, 41, 774), 3, 3, 2 },
                    { 9, new TimeSpan(0, 0, 5, 37, 292), 3, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gokarty",
                keyColumn: "IdGokart",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gokarty",
                keyColumn: "IdGokart",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KierowcaSponsor",
                keyColumns: new[] { "IdKierowca", "IdSponsor" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "KierowcaSponsor",
                keyColumns: new[] { "IdKierowca", "IdSponsor" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "KierowcaSponsor",
                keyColumns: new[] { "IdKierowca", "IdSponsor" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "IdPrzejazd",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sprzety",
                keyColumn: "IdSprzet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sprzety",
                keyColumn: "IdSprzet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sprzety",
                keyColumn: "IdSprzet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gokarty",
                keyColumn: "IdGokart",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kierowcy",
                keyColumn: "IdKierowca",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kierowcy",
                keyColumn: "IdKierowca",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kierowcy",
                keyColumn: "IdKierowca",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nadwozia",
                keyColumn: "IdNadwozie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nadwozia",
                keyColumn: "IdNadwozie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Podwozia",
                keyColumn: "IdPodwozie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Podwozia",
                keyColumn: "IdPodwozie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Silniki",
                keyColumn: "IdSilnik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Silniki",
                keyColumn: "IdSilnik",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sponsorzy",
                keyColumn: "IdSponsor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponsorzy",
                keyColumn: "IdSponsor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sponsorzy",
                keyColumn: "IdSponsor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "IdAdres",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "IdAdres",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nadwozia",
                keyColumn: "IdNadwozie",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Podwozia",
                keyColumn: "IdPodwozie",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Silniki",
                keyColumn: "IdSilnik",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tory",
                keyColumn: "IdTor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "IdUzytkownik",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "IdAdres",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Nazwa",
                table: "Tory",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Koszt",
                table: "Sprzety",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
