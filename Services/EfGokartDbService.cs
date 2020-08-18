using GokartyProjekt.DTOs;
using GokartyProjekt.DTOs.Requests;
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

        public void AddNewLapTime(AddNewLapTimeRequest request)
        {
            var track = _context.Tory.Any(t => t.IdTor == request.IdTor);
            if (!track)
            {
                throw new NoTrackException($"Track with id = {request.IdTor} does not exist!");
            }
            var gokart = _context.Gokarty.Any(g => g.IdGokart == request.IdGokart);

            if (!gokart)
            {
                throw new NoGokartException($"Gokart with id = {request.IdGokart} does not exist!");
            }

            var driver = _context.Kierowcy.Any(k => k.IdKierowca == request.IdKierowca);

            if (!driver)
            {
                throw new NoDriverException($"Driver with id = {request.IdKierowca} does not exist!");
            }

            if (request.DataPrzejazdu.CompareTo(DateTime.Now) > 0)
            {
                throw new DateIsLaterThanNowException($"Date {request.DataPrzejazdu} is later than current date!");
            }

            var newLap = new Przejazd
            {
                Czas = TimeSpan.Parse(request.Czas),
                DataPrzejazdu = request.DataPrzejazdu,
                IdTor = request.IdTor,
                IdGokart = request.IdGokart,
                IdKierowca = request.IdKierowca
            };

            /*  
                Przykładowy request z Postmana

                "Czas": "00:04:00.089",
                "DataPrzejazdu":"2019-06-17T14:37:39.000",
                "IdTor": 3,
                "IdGokart": 3,
                "IdKierowca": 1
            */

            _context.Przejazdy.Add(newLap);
            _context.SaveChanges();
        }

    }
}
