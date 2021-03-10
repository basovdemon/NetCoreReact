using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreReact.Core.Intefaces;
using NetCoreReact.Core.Models;
using NetCoreReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        [ActionName("GetEventAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventModel>> GetEventAsync(Guid id)
        {
            var evnt = await _eventService.GetEventAsync(id);

            if (evnt is null) return NotFound();

            return Ok(evnt);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventModel>>> GetEventsAsync()
        {
            var events = await _eventService.GetEventsAsync();

            return Ok(events);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EventModel>> CreateEventAsync(CreateEventModel createEventModel)
        {
            var eventModel = new EventModel
            {
                Title = createEventModel.Title,
                Description = createEventModel.Description,
                StartDate = createEventModel.StartDate,
                EndDate = createEventModel.EndDate,
                AllDay = createEventModel.AllDay,
                Place = createEventModel.Place
            };

            var createdEvent = await _eventService.CreateEventAsync(eventModel);

            return CreatedAtAction(nameof(GetEventAsync), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateEventAsync(Guid id, UpdateEventModel updateEventModel)
        {
            if (id != updateEventModel.Id) return BadRequest();

            var evnt = await _eventService.GetEventAsync(id);

            if (evnt is null) return NotFound();

            var eventModel = new EventModel
            {
                Id = id,
                Title = updateEventModel.Title,
                Description = updateEventModel.Description,
                StartDate = updateEventModel.StartDate,
                EndDate = updateEventModel.EndDate,
                AllDay = updateEventModel.AllDay,
                Place = updateEventModel.Place
            };

            var updatedEvent = await _eventService.UpdateEventAsync(eventModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEventAsync(Guid id)
        {
            var evnt = await _eventService.GetEventAsync(id);

            if (evnt is null) return NotFound();

            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
