using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class GokartyDbContext : DbContext
    {
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Gokart> Gokarty { get; set; }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<KierowcaSponsor> KierowcaSponsor { get; set; }
        public DbSet<Nadwozie> Nadwozia { get; set; }
        public DbSet<Podwozie> Podwozia { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Przejazd> Przejazdy { get; set; }
        public DbSet<Silnik> Silniki { get; set; }
        public DbSet<Sponsor> Sponsorzy { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Tor> Tory { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }

        public GokartyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adres>(opt =>
            {
                opt.HasKey(p => p.IdAdres);

                opt.Property(p => p.IdAdres).ValueGeneratedOnAdd();

                opt.Property(p => p.Panstwo)
                    .HasMaxLength(50)
                    .IsRequired();

                opt.Property(p => p.Miasto)
                     .HasMaxLength(50)
                     .IsRequired();

                opt.Property(p => p.Ulica)
                    .HasMaxLength(50)
                    .IsRequired();

                opt.HasOne(p => p.Tor)
                    .WithOne(p => p.Adres)
                    .HasForeignKey<Tor>(p => p.IdAdres);

            });

            modelBuilder.Entity<Gokart>(opt =>
            {
                opt.HasKey(p => p.IdGokart);

                opt.Property(p => p.IdGokart).ValueGeneratedOnAdd();

                opt.Property(p => p.Nazwa)
                    .HasMaxLength(50)
                    .IsRequired();

                opt.HasMany(p => p.Przejazdy)
                    .WithOne(p => p.Gokart)
                    .HasForeignKey(p => p.IdGokart);

                opt.HasOne(p => p.Nadwozie)
                    .WithMany(p => p.Gokarty)
                    .HasForeignKey(p => p.IdNadwozie);

                opt.HasOne(p => p.Podwozie)
                    .WithMany(p => p.Gokarty)
                    .HasForeignKey(p => p.IdPodwozie);

                opt.HasOne(p => p.Silnik)
                    .WithMany(p => p.Gokarty)
                    .HasForeignKey(p => p.IdSilnik);

            });

            modelBuilder.Entity<Kierowca>(opt =>
            {
                opt.HasKey(p => p.IdKierowca);

                opt.Property(p => p.IdKierowca).ValueGeneratedOnAdd();

                opt.Property(p => p.Imie)
                  .IsRequired();

                opt.Property(p => p.Nazwisko)
                    .IsRequired();

                opt.Property(p => p.NumerKarty)
                    .HasMaxLength(20)
                    .IsRequired();

                opt.HasMany(p => p.Sprzety)
                     .WithOne(p => p.Kierowca)
                     .HasForeignKey(p => p.IdKierowca);

                opt.HasMany(p => p.KierowcaSponsor)
                    .WithOne(p => p.Kierowca)
                    .HasForeignKey(p => p.IdKierowca);

                opt.HasMany(p => p.Przejazdy)
                    .WithOne(p => p.Kierowca)
                    .HasForeignKey(p => p.IdKierowca);

                opt.HasOne(p => p.Uzytkownik)
                    .WithOne(p => p.Kierowca)
                    .HasForeignKey<Kierowca>(p => p.IdUzytkownik);

            });

            modelBuilder.Entity<KierowcaSponsor>(opt =>
            {
                opt.HasKey(p => new {
                    p.IdKierowca,
                    p.IdSponsor
                });
            });

            modelBuilder.Entity<Nadwozie>(opt =>
            {
                opt.HasKey(p => p.IdNadwozie);

                opt.Property(p => p.IdNadwozie).ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Podwozie>(opt =>
            {
                opt.HasKey(p => p.IdPodwozie);

                opt.Property(p => p.IdPodwozie).ValueGeneratedOnAdd();

            });


            modelBuilder.Entity<Pracownik>(opt =>
            {
                opt.HasKey(p => p.IdPracownik);

                opt.Property(p => p.IdPracownik).ValueGeneratedOnAdd();

                opt.Property(p => p.Imie)
                    .IsRequired();

                opt.Property(p => p.Nazwisko)
                    .IsRequired();

                opt.Property(p => p.Stanowisko)
                     .HasMaxLength(50)
                     .IsRequired();

                opt.Property(p => p.Wynagrodzenie)
                    .HasColumnType("money")
                    .IsRequired();

                opt.HasOne(p => p.Uzytkownik)
                    .WithOne(p => p.Pracownik)
                    .HasForeignKey<Pracownik>(p => p.IdUzytkownik);

                opt.HasOne(p => p.Tor)
                    .WithMany(p => p.Pracownicy)
                    .HasForeignKey(p => p.IdTor);

            });

            modelBuilder.Entity<Przejazd>(opt =>
            {

                opt.HasKey(p => p.IdPrzejazd);

                opt.Property(p => p.IdPrzejazd).ValueGeneratedOnAdd();

                opt.Property(p => p.Czas)
                    .HasColumnType("time")
                    .IsRequired();

                opt.HasOne(p => p.Tor)
                    .WithMany(p => p.Przejazdy)
                    .HasForeignKey(p => p.IdTor);

            });

            modelBuilder.Entity<Silnik>(opt =>
            {
                opt.HasKey(p => p.IdSilnik);

                opt.Property(p => p.IdSilnik).ValueGeneratedOnAdd();

                opt.Property(p => p.Producent)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sponsor>(opt =>
            {

                opt.HasKey(p => p.IdSponsor);

                opt.Property(p => p.IdSponsor).ValueGeneratedOnAdd();

                opt.HasMany(p => p.KierowcaSponsor)
                    .WithOne(p => p.Sponsor)
                    .HasForeignKey(p => p.IdSponsor);

            });

            modelBuilder.Entity<Sprzet>(opt =>
            {

                opt.HasKey(p => p.IdSprzet);

                opt.Property(p => p.IdSprzet).ValueGeneratedOnAdd();

                opt.Property(p => p.Nazwa)
                    .HasMaxLength(50)
                    .IsRequired();

            });

            modelBuilder.Entity<Tor>(opt =>
            {

                opt.HasKey(p => p.IdTor);

                opt.Property(p => p.IdTor).ValueGeneratedOnAdd();

                opt.Property(p => p.Nazwa)
                    .HasMaxLength(50)
                    .IsRequired();

                opt.Property(p => p.StawkaGodzinowa)
                    .HasColumnType("money");

                opt.HasMany(p => p.Gokarty)
                    .WithOne(p => p.Tor)
                    .HasForeignKey(p => p.IdTor);

            });


            modelBuilder.Entity<Uzytkownik>(opt =>
            {
                opt.HasKey(p => p.IdUzytkownik);

                opt.Property(p => p.IdUzytkownik).ValueGeneratedOnAdd();

                opt.Property(p => p.Login)
                    .HasMaxLength(30);

                opt.Property(p => p.Haslo)
                    .HasMaxLength(30);
            });

            SeedData(modelBuilder);
        }
        public void SeedData(ModelBuilder modelBuilder)
        {

            //Adresy
            var Adresy = new List<Adres>();
            Adresy.Add(new Adres
            {
                IdAdres = 1,
                Panstwo = "Włochy",
                Miasto = "Monza",
                Ulica = "Viale di Vedano, 5"
            });;

            Adresy.Add(new Adres
            {
                IdAdres = 2,
                Panstwo = "Belgia",
                Miasto = "Stavelot",
                Ulica = "Route du Circuit 55"
            });;

            Adresy.Add(new Adres
            {
                IdAdres = 3,
                Panstwo = "Holandia",
                Miasto = "Zandvoort",
                Ulica = "Burgemeester van Alphenstraat 108"
            });;

            //Gokarty
            var Gokarty = new List<Gokart>();
            Gokarty.Add(new Gokart
            {
               IdGokart = 1,
               Nazwa = "Junior",
               Waga = 150,
               IdSilnik = 2,
               IdNadwozie = 2,
               IdPodwozie = 2,
               IdTor = 3
            });;

            Gokarty.Add(new Gokart
            {
               IdGokart = 2,
               Nazwa = "Standard",
               Waga = 160,
               IdSilnik = 1,
               IdNadwozie = 1,
               IdPodwozie = 1,
               IdTor = 1
            });;

            Gokarty.Add(new Gokart
            {
                IdGokart = 3,
                Nazwa = "Standard+",
                Waga = 180,
                IdSilnik = 3,
                IdNadwozie = 3,
                IdPodwozie = 3,
                IdTor = 2
            });;

            //Kierowcy
            var Kierowcy = new List<Kierowca>();
            Kierowcy.Add(new Kierowca
            {
                IdKierowca = 1,
                Imie = "Tomasz",
                Nazwisko = "Kowalski",
                Wiek = 21,
                NumerKarty = "k1704",
                IdUzytkownik = 1
            });;

            Kierowcy.Add(new Kierowca
            {
                IdKierowca = 2,
                Imie = "Marcin",
                Nazwisko = "Pędziwiatr",
                Wiek = 16,
                NumerKarty = "k898",
                IdUzytkownik = 2
            });;

            Kierowcy.Add(new Kierowca
            {
                IdKierowca = 3,
                Imie = "Jakub",
                Nazwisko = "Mazur",
                Wiek = 18,
                NumerKarty = "k19",
                IdUzytkownik = 3
            });;

            //Kierowcy-Sponsorzy
            var KierowcySponsorzy = new List<KierowcaSponsor>();
            KierowcySponsorzy.Add(new KierowcaSponsor
            {
                IdKierowca = 1,
                IdSponsor = 2
            });;

            KierowcySponsorzy.Add(new KierowcaSponsor
            {
                IdKierowca = 2,
                IdSponsor = 1
            });;

            KierowcySponsorzy.Add(new KierowcaSponsor
            {
                IdKierowca = 3,
                IdSponsor = 3
            });;

            //Nadwozia
            var Nadwozia = new List<Nadwozie>();
            Nadwozia.Add(new Nadwozie
            {
                IdNadwozie = 1,
                Producent = "Alfa Romeo"
            });;

            Nadwozia.Add(new Nadwozie
            {
                IdNadwozie = 2,
                Producent = "Honda"
            });;

            Nadwozia.Add(new Nadwozie
            {
                IdNadwozie = 3,
                Producent = "Chevrolet"
            }); ;

            //Podwozia
            var Podwozia = new List<Podwozie>();
            Podwozia.Add(new Podwozie
            {
                IdPodwozie = 1,
                Producent = "Alfa Romeo"
            });;

            Podwozia.Add(new Podwozie
            {
                IdPodwozie = 2,
                Producent = "Honda"
            });;

            Podwozia.Add(new Podwozie
            {
                IdPodwozie = 3,
                Producent = "Chevrolet"
            });;

            //Pracownicy
            var Pracownicy = new List<Pracownik>();
            Pracownicy.Add(new Pracownik
            {
                IdPracownik = 1,
                Imie = "Paweł",
                Nazwisko = "Wójcik",
                Wiek = 25,
                Stanowisko = "Recepcjonista",
                Wynagrodzenie = 3300,
                IdTor = 1,
                IdUzytkownik = 1
             });;

            Pracownicy.Add(new Pracownik
            {
                IdPracownik = 2,
                Imie = "Robert",
                Nazwisko = "Walczak",
                Wiek = 31,
                Stanowisko = "Instruktor",
                Wynagrodzenie = 4500,
                IdTor = 2,
                IdUzytkownik = 2
            });;

            Pracownicy.Add(new Pracownik
            {
                IdPracownik = 3,
                Imie = "Krzysztof",
                Nazwisko = "Błyskawica",
                Wiek = 28,
                Stanowisko = "Kierownik toru",
                Wynagrodzenie = 5500,
                IdTor = 3,
                IdUzytkownik = 3
            });;

            //Przejazdy
            var Przejazdy = new List<Przejazd>();
            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 1,
                Czas = new TimeSpan (0, 0, 4, 25, 732),
                IdTor = 1,
                IdGokart = 3,
                IdKierowca = 1
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 2,
                Czas = new TimeSpan(0, 0, 4, 27, 319),
                IdTor = 1,
                IdGokart = 3,
                IdKierowca = 1
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 3,
                Czas = new TimeSpan(0, 0, 4, 25, 588),
                IdTor = 1,
                IdGokart = 3,
                IdKierowca = 1
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 4,
                Czas = new TimeSpan(0, 0, 3, 59, 711),
                IdTor = 3,
                IdGokart = 3,
                IdKierowca = 2,
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 5,
                Czas = new TimeSpan(0, 0, 3, 59, 646),
                IdTor = 3,
                IdGokart = 3,
                IdKierowca = 2,
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 6,
                Czas = new TimeSpan(0, 0, 4, 02, 011),
                IdTor = 3,
                IdGokart = 3,
                IdKierowca = 2,
            });;

            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 7,
                Czas = new TimeSpan(0, 0, 05, 38, 412),
                IdTor = 2,
                IdGokart = 3,
                IdKierowca = 3,
            });;


            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 8,
                Czas = new TimeSpan(0, 0, 05, 41, 774),
                IdTor = 2,
                IdGokart = 3,
                IdKierowca = 3,
            });;
            Przejazdy.Add(new Przejazd
            {
                IdPrzejazd = 9,
                Czas = new TimeSpan(0, 0, 05, 37, 292),
                IdTor = 2,
                IdGokart = 3,
                IdKierowca = 3,
            }); ;

            //Silniki
            var Silniki = new List<Silnik>();
            Silniki.Add(new Silnik
            {
                IdSilnik = 1,
                Moc = 20,
                Pojemnosc = 600,
                Producent = "Mercedes"
            });;

            Silniki.Add(new Silnik
            {
                IdSilnik = 2,
                Moc = 15,
                Pojemnosc = 350,
                Producent = "Audi"
            });;

            Silniki.Add(new Silnik
            {
                IdSilnik = 3,
                Moc = 25,
                Pojemnosc = 800,
                Producent = "Ferrari"
            });;

            //Sponsorzy
            var Sponsorzy = new List<Sponsor>();
            Sponsorzy.Add(new Sponsor
            {
                IdSponsor = 1,
                Nazwa = "ORLEN"
            });;

            Sponsorzy.Add(new Sponsor
            {
                IdSponsor = 2,
                Nazwa = "STS"
            });;

            Sponsorzy.Add(new Sponsor
            {
                IdSponsor = 3,
                Nazwa = "PEKAO"
            });;

            //Sprzety
            var Sprzety = new List<Sprzet>();
            Sprzety.Add(new Sprzet
            {
                IdSprzet = 1,
                Nazwa = "Kask czerwony mały",
                Koszt = 25.0,
                IdKierowca = 1
            });;

            Sprzety.Add(new Sprzet
            {
                IdSprzet = 2,
                Nazwa = "Rękawice czarne normalne",
                Koszt = 15,
                IdKierowca = null
            });;

            Sprzety.Add(new Sprzet
            {
                IdSprzet = 3,
                Nazwa = "Kominiarka normalna",
                Koszt = 10,
                IdKierowca = 3
            });;

            //Tory
            var Tory = new List<Tor>();
            Tory.Add(new Tor
            {
                IdTor = 1,
                Nazwa = "Autodromo Nazionale di Monza",
                Dlugosc = 5.793,
                StawkaGodzinowa = 400,
                IdAdres = 1
            });;

            Tory.Add(new Tor
            {
                IdTor = 2,
                Nazwa = "Circuit de Spa-Francorchamps",
                Dlugosc = 7.004,
                StawkaGodzinowa = 450,
                IdAdres = 2
            });;

            Tory.Add(new Tor
            {
                IdTor = 3,
                Nazwa = "Circuit Zandvoort",
                Dlugosc = 4.252,
                StawkaGodzinowa = 350,
                IdAdres = 3
            });;

            //Uzytkownicy
            var Uzytkownicy = new List<Uzytkownik>();
            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 1,
                Login = "tkowalski",
                Haslo = "kowalski12",
            });;

            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 2,
                Login = "mpedzi",
                Haslo = "pedziwiatr2016",
            });;

            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 3,
                Login = "jmazur",
                Haslo = "mazurek",
            });;

            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 4,
                Login = "pwojcik",
                Haslo = "wojcik95",
            });;

            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 5,
                Login = "rwalczak",
                Haslo = "walczakxd",
            });;

            Uzytkownicy.Add(new Uzytkownik
            {
                IdUzytkownik = 6,
                Login = "krzysiu44",
                Haslo = "krzysiekblyskawica",
            }); ;

            //Dodanie
            modelBuilder.Entity<Adres>().HasData(Adresy);
            modelBuilder.Entity<Gokart>().HasData(Gokarty);
            modelBuilder.Entity<Kierowca>().HasData(Kierowcy);
            modelBuilder.Entity<KierowcaSponsor>().HasData(KierowcySponsorzy);
            modelBuilder.Entity<Nadwozie>().HasData(Nadwozia);
            modelBuilder.Entity<Podwozie>().HasData(Podwozia);
            modelBuilder.Entity<Pracownik>().HasData(Pracownicy);
            modelBuilder.Entity<Przejazd>().HasData(Przejazdy);
            modelBuilder.Entity<Silnik>().HasData(Silniki);
            modelBuilder.Entity<Sponsor>().HasData(Sponsorzy);
            modelBuilder.Entity<Sprzet>().HasData(Sprzety);
            modelBuilder.Entity<Tor>().HasData(Tory);
            modelBuilder.Entity<Uzytkownik>().HasData(Uzytkownicy);
        }
    }
}