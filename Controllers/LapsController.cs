using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GokartyProjekt.Exceptions;
using GokartyProjekt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GokartyProjekt.Controllers
{
    [Route("api/laps")]
    [ApiController]
    public class LapsController : ControllerBase
    {
        private IGokartDbService _service;

        public LapsController(IGokartDbService service)
        {
            _service = service;
        }

        [Route("track/{IdTor}")]
        [HttpGet]  
        public IActionResult FastestLapOnGivenTrack(int IdTor)
        {
            try
            {
                var response = _service.FastestLapOnGivenTrack(IdTor);
                return Ok(response);
            }
            catch (NoTrackException exc)
            {
                return BadRequest(exc.Message);
            }

            catch (NoLapsMadeOnTrackException exc)
            {
                return NotFound(exc.Message);
            }
        }

        [Route("track/month/{IdTor}")]
        [HttpGet]
        public IActionResult FastestLapOnGivenTrackInMonth(int IdTor)
        {
            try
            {
                var response = _service.FastestLapOnGivenTrackInMonth(IdTor);
                return Ok(response);
            }
            catch (NoTrackException exc)
            {
                return BadRequest(exc.Message);
            }

            catch (NoLapsMadeOnTrackException exc)
            {
                return NotFound(exc.Message);
            }
        }
        [Route("pb/{IdKierowca}/{IdTor}")]
        [HttpGet]
        public IActionResult PersonalBestOnGivenTrack(int IdKierowca, int IdTor)
        {
            try
            {
                var response = _service.PersonalBestOnGivenTrack(IdKierowca, IdTor);
                return Ok(response);
            }
            catch (NoDriverException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (NoTrackException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (NoLapsMadeOnTrackException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
