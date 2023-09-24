
using System;
using System.Collections.Generic;

namespace TechnicalTask.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public Guid EventUUId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Attendee> Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
