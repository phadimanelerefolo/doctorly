using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTask.Data;
using TechnicalTask.Data.Entities;
using TechnicalTask.Domain.Services;

namespace TechnicalTask.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class APIController : ControllerBase
    {
        private readonly IEventService _eventService;
        public APIController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Retrieves a list of all events.
        /// </summary>
        /// <returns>A list of events.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        /// <summary>
        /// Retrieves an event by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>The event with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _eventService.GetEventByIdAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="event">The event to create.</param>
        /// <returns>The newly created event.</returns>
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event @event)
        {
            if (@event == null)
            {
                return BadRequest();
            }

            var createdEvent = await _eventService.CreateEventAsync(@event);
            return CreatedAtAction(nameof(GetEvent), new { id = createdEvent.Id }, createdEvent);
        }

        /// <summary>
        /// Updates an existing event.
        /// </summary>
        /// <param name="id">The ID of the event to update.</param>
        /// <param name="event">The updated event data.</param>
        /// <returns>NoContent response if the update is successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            await _eventService.UpdateEventAsync(id, @event);
            return NoContent();
        }

        /// <summary>
        /// Deletes an event by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the event to delete.</param>
        /// <returns>NoContent response if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
