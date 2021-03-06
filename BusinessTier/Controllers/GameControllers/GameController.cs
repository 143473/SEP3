using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.GameWebServices.Games;
using BusinessTier.MiddlePoint.GameMiddlePoints.Games;
using BusinessTier.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.GameControllers
{
    [ApiController]
    [Route ("Game")]
    public class GameController : Controller
    {
        private readonly IGameWebService gameWebService;
        private readonly IGameMiddlePoint gameMiddlePoint;

        public GameController(IGameWebService gameWebService, IGameMiddlePoint gameMiddlePoint)
        {
            this.gameWebService = gameWebService;
            this.gameMiddlePoint = gameMiddlePoint;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Game>> GetGameAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await gameWebService.GetGameAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GGL")]
        public async Task<ActionResult<IList<Game>>> GetLimitedSearchGglAsync([FromQuery] FilterRest filterRest)
        {
            try
            {
                var searchGglList = await gameMiddlePoint.GetLimitedSearchGglAsync(filterRest);
                return Ok(searchGglList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("/SuggestedGames")]
        public async Task<ActionResult<IList<Game>>> GetSuggestedGamesAsync()
        {
            try
            {
                var games = await gameWebService.GetSuggestedGamesAsync();
                return Ok(games);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> RemoveGameAsync([FromRoute] int id)
        {
            try
            {
                await gameWebService.RemoveGameAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/SuggestedGames")]
        public async Task<ActionResult<Game>> SuggestGameAsync([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await gameWebService.SuggestGameAsync(game);
                return Created($"/{game.id}", game);
                // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGameAsync([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await gameMiddlePoint.AddGameAsync(game);
                return Created($"/{game.id}", game); 
                // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("Approval")]
        public async Task<ActionResult<Game>> EditGameApprovalAsync([FromBody] Game game)
        {
            try
            {
                await gameMiddlePoint.EditGameApprovalAsync(game);
                return Ok(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Game>> EditGameAsync([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await gameWebService.EditGameAsync(game);
                return Ok(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}