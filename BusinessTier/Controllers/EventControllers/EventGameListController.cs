using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.EventGameLists;
using BusinessTier.MiddlePoint.EventMiddlePoints;
using BusinessTier.MiddlePoint.EventMiddlePoints.EventGameLists;
using BusinessTier.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTier.Controllers.EventControllers
{
    [ApiController]
    [Route ("EventGameList")]
    public class EventGameListController : Controller
    {
        private readonly IEventGameListWebService eventGameListWebService;
        private readonly IEventGameListMiddlePoint eventGameListMiddlePoint;

        public EventGameListController(IEventGameListWebService eventGameListWebService, IEventGameListMiddlePoint eventGameListMiddlePoint)
        {
            this.eventGameListWebService = eventGameListWebService;
            this.eventGameListMiddlePoint = eventGameListMiddlePoint;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IList<Game>>> GetAllEventGameListAsync(int id)
        {
            try
            {
                IList<Game> allEventGameList = await eventGameListWebService.GetAllEventGameListAsync(id);
                return Ok(allEventGameList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/UpdateEventGame")]
        public async Task UpdateEventGamesAsync([FromBody] EventGameListUpdate eventGameListUpdate)
        {
            await eventGameListMiddlePoint.EventGameListUpdateAsync(eventGameListUpdate);
        }
    }
}