using System;
using Kolokwium.Models;
using Kolokwium.RequestExeptions;
using Kolokwium.Requests;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IChampionshipDbService _service;

        public PlayerController(IChampionshipDbService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok();
        }

        [Route("/championships/{id:int}/teams")]
        [HttpGet]
        public IActionResult GetTeamsSorted(int id)
        {
            try
            {
                var result = _service.GetTeamsSorted(id);
                return Ok(result);
            }
            catch (NoTeamsFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest("Bad Request");
            }

        }

        [HttpPost("/teams/{id}/players")]
        public IActionResult AddPlayerToTeam(int id, AddPlayerRequest addPlayerRequest)
        {
            try
            {
                _service.AddPlayer(addPlayerRequest, id);
                return Ok();
            }
            catch (PlayerNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (NoTeamsFoundException e)
            {
                return NotFound(e.Message);
            }
            //todo last exeptions
        }
    }

}
