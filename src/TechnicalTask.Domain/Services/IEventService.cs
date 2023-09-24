using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTask.Data.Entities;

namespace TechnicalTask.Domain.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<Event> CreateEventAsync(Event event1);
        Task UpdateEventAsync(int eventId, Event event1);
        Task DeleteEventAsync(int eventId);
}
}
