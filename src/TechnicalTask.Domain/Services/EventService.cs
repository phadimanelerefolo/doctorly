using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTask.Data.Entities;
using TechnicalTask.Domain.Repositories;

namespace TechnicalTask.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _eventRepository.GetEventByIdAsync(eventId);
        }

        public async Task<Event> CreateEventAsync(Event @event)
        {
            return await _eventRepository.CreateEventAsync(@event);
        }

        public async Task UpdateEventAsync(int eventId, Event @event)
        {
            await _eventRepository.UpdateEventAsync(eventId, @event);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            await _eventRepository.DeleteEventAsync(eventId);
        }
    }
}
