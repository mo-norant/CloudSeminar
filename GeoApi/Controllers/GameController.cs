using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoApi.Entitities.POI;
using GeoGame.Entitities.Models;
using GeoGame.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IAreaService areaService;

        public GameController(IAreaService areaService)
        {
            this.areaService = areaService;
        }

        [HttpGet("{GameID}")]
        public async Task<IActionResult> GetMap([FromRoute] int GameID)
        {
            if (!ModelState.IsValid) return BadRequest();
            var game = await areaService.GetGame(GameID);
            if (game == null) return NotFound();
            return Ok(game);

        }


        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameDTO gamedto, [FromQuery] int difficulty)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (difficulty == 0) return BadRequest("Gelieve aantal punten mee te geven");

            Game game =  await areaService.CreateGame(gamedto.StartLocation, gamedto.playersIDs ,difficulty);
            return Ok(game);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Gettest()
        {
            return Ok("Authorize");
        }

    }
}