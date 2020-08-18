using GokartyProjekt.DTOs;
using GokartyProjekt.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Services
{
    public interface IGokartDbService
    {
        public UniversalFastestLapOnGivenTrackResponse FastestLapOnGivenTrack(int IdTor);
        public UniversalFastestLapOnGivenTrackResponse FastestLapOnGivenTrackInMonth(int IdTor);
        public PersonalBestOnGivenTrackResponse PersonalBestOnGivenTrack(int IdKierowca, int IdTor);
        
        // TODO: Ręczne dodawanie czasów, porównywanie z innymi kierowcami


    }
}
