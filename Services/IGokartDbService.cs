using GokartyProjekt.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Services
{
    public interface IGokartDbService
    {
        public LapOnGivenTrackResponse FastestLapOnGivenTrack(int IdTor);
        // TODO: Ręczne dodawanie czasów, rekordy miesiąca, roku, dnia (wymaga rozszerzenia przejazdów)


    }
}
