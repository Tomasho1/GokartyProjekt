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
        }
    }
}