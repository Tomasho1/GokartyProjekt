﻿using GokartyProjekt.DTOs;
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

        public LapOnGivenTrackResponse FastestLapOnGivenTrack(int IdTor)
        {
            var track = _context.Tory.SingleOrDefault(t => t.IdTor == IdTor);

            if (track == null)
            {
                throw new NoTrackException($"Track with id = {IdTor} does not exist");
            }

            var allLaps = _context.Przejazdy.Where(p => p.IdTor == track.IdTor);
            var fastestLap = allLaps.OrderBy(l => l.Czas).FirstOrDefault();
            var driver = _context.Kierowcy.SingleOrDefault(k => k.IdKierowca == fastestLap.IdKierowca);
            var gokart = _context.Gokarty.SingleOrDefault(g => g.IdGokart == fastestLap.IdGokart);

            var response = new LapOnGivenTrackResponse
            {
                Imie = driver.Imie,
                Nazwisko = driver.Nazwisko,
                IdKierowca = driver.IdKierowca,
                Minuty = fastestLap.Czas.Minutes,
                Sekundy = fastestLap.Czas.Seconds,
                Milisekundy = fastestLap.Czas.Milliseconds,
                NazwaGokartu = gokart.Nazwa
            };

            return response;
        }
    }
}
