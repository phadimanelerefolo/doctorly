using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTask.Data;
using TechnicalTask.Data.Entities;

namespace TechnicalTask.Domain.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _context.Event.FindAsync(eventId);
        }

        public async Task<Event> CreateEventAsync(Event @event)
        {
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();
            return @event;
        }

        public async Task UpdateEventAsync(int eventId, Event @event)
        {
            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var @event = await _context.Event.FindAsync(eventId);
            if (@event != null)
            {
                _context.Event.Remove(@event);
                await _context.SaveChangesAsync();
            }
        }
    }
}
