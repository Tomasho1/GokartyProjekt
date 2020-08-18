using GokartyProjekt.DTOs;
using GokartyProjekt.DTOs.Responses;
using GokartyProjekt.Exceptions;
using GokartyProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Services
{
    public class EfGokartDbService : IGokartDbService
    {
        private readonly GokartyDbContext _context;

        public EfGokartDbService(GokartyDbContext context)
        {
            _context = context;
        }

        public UniversalFastestLapOnGivenTrackResponse FastestLapOnGivenTrack(int IdTor)
        {
            var track = _context.Tory.FirstOrDefault(t => t.IdTor == IdTor);

            if (track == null)
            {
                throw new NoTrackException($"Track with id = {IdTor} does not exist!");
            }

            var fastestLap = _context.Przejazdy.Where(p => p.IdTor == track.IdTor).OrderBy(l => l.Czas).FirstOrDefault();

            if (fastestLap == null)
            {
                throw new NoLapsMadeOnTrackException($"No laps made on track with id = {IdTor}!");
            }

            var driver = _context.Kierowcy.SingleOrDefault(k => k.IdKierowca == fastestLap.IdKierowca);
            var gokart = _context.Gokarty.SingleOrDefault(g => g.IdGokart == fastestLap.IdGokart);

            var response = new UniversalFastestLapOnGivenTrackResponse
            {
                Imie = driver.Imie,
                Nazwisko = driver.Nazwisko,
                IdKierowca = driver.IdKierowca,
                DataPrzejazdu = fastestLap.DataPrzejazdu,
                Minuty = fastestLap.Czas.Minutes,
                Sekundy = fastestLap.Czas.Seconds,
                Milisekundy = fastestLap.Czas.Milliseconds,
                NazwaGokartu = gokart.Nazwa
            };

            return response;
        }

        public UniversalFastestLapOnGivenTrackResponse FastestLapOnGivenTrackInMonth(int IdTor)
        {
            var track = _context.Tory.FirstOrDefault(t => t.IdTor == IdTor);

            if (track == null)
            {
                throw new NoTrackException($"Track with id = {IdTor} does not exist!");
            }

            var fastestLap = _context.Przejazdy.Where(p => p.IdTor == track.IdTor).Where(p => p.DataPrzejazdu.Month == DateTime.Now.Month).OrderBy(l => l.Czas).FirstOrDefault();

            if (fastestLap == null)
            {
                throw new NoLapsMadeOnTrackException($"No laps made on track with id = {IdTor} in this month!");
            }

            var driver = _context.Kierowcy.SingleOrDefault(k => k.IdKierowca == fastestLap.IdKierowca);
            var gokart = _context.Gokarty.SingleOrDefault(g => g.IdGokart == fastestLap.IdGokart);

            var response = new UniversalFastestLapOnGivenTrackResponse
            {
                Imie = driver.Imie,
                Nazwisko = driver.Nazwisko,
                IdKierowca = driver.IdKierowca,
                DataPrzejazdu = fastestLap.DataPrzejazdu,
                Minuty = fastestLap.Czas.Minutes,
                Sekundy = fastestLap.Czas.Seconds,
                Milisekundy = fastestLap.Czas.Milliseconds,
                NazwaGokartu = gokart.Nazwa
            };

            return response;
        }

        public PersonalBestOnGivenTrackResponse PersonalBestOnGivenTrack(int IdKierowca, int IdTor)
        {
            var driver = _context.Kierowcy.FirstOrDefault(k => k.IdKierowca == IdKierowca);
            var track = _context.Tory.FirstOrDefault(t => t.IdTor == IdTor);

            if (driver == null)
            {
                throw new NoDriverException($"Driver with id = {IdKierowca} does not exist!");
            }

            if (track == null)
            {
                throw new NoTrackException($"Track with id = {IdTor} does not exist!");
            }

            var fastestLap = _context.Przejazdy.Where(k=> k.IdKierowca == IdKierowca).Where(p => p.IdTor == track.IdTor).OrderBy(l => l.Czas).FirstOrDefault();

            if (fastestLap == null)
            {
                throw new NoLapsMadeOnTrackException($"Driver with id = {IdKierowca} made no laps on track with id = {IdTor}");
            }
            var gokart = _context.Gokarty.SingleOrDefault(g => g.IdGokart == fastestLap.IdGokart);

            var response = new PersonalBestOnGivenTrackResponse
            {
                DataPrzejazdu = fastestLap.DataPrzejazdu,
                Minuty = fastestLap.Czas.Minutes,
                Sekundy = fastestLap.Czas.Seconds,
                Milisekundy = fastestLap.Czas.Milliseconds,
                NazwaGokartu = gokart.Nazwa
            };

            return response;
        }
    }
}
