using GokartyProjekt.DTOs;
using GokartyProjekt.DTOs.Requests;
using GokartyProjekt.DTOs.Responses;
using GokartyProjekt.Models;
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
        public void AddNewLapTime(AddNewLapTimeRequest request);
        // TODO: Porównywanie z innymi kierowcami, wyświetlanie wszystkich czasów danego kierowcy z deltą względem najszybsze


    }
}
