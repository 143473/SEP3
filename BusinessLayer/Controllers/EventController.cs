using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("Event")]
    public class EventController : Controller
    {
        private IEventWebService EventWebService;
        private IEventMiddlePoint eventMiddlePoint;

        public EventController(IEventWebService eventWebService, IEventMiddlePoint eventMiddlePoint)
        {
            EventWebService = eventWebService;
            this.eventMiddlePoint = eventMiddlePoint;
        }

        [HttpGet]
        [Route("/FilteredEvents")]
        public async Task<ActionResult<IList<Event>>> GetFilteredEventsAsync([FromQuery] FilterREST filterRest)
        {
            try
            {
                EventList filteredEventsAsync = await eventMiddlePoint.eventFilter(filterRest);
                return Ok(filteredEventsAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Event>> GetEventAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var response = await EventWebService.GetEventAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] Event Event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await EventWebService.CreateEventAsync(Event);
                return Ok(Event);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Event>> UpdateEventAsync([FromBody] Event Event)
        {
            try
            {
                await EventWebService.EditEventAsync(Event);
                return Ok(Event);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("/Events/{id}")]
        public async Task<ActionResult<Event>> CancelEventAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await EventWebService.CancelEventAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}