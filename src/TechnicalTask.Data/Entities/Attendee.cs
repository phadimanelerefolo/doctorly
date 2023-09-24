using System;

namespace TechnicalTask.Data.Entities
{
    public class Attendee
    {
        public int Id { get; set; }
        public Guid AttendeeUUId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool Attending { get; set; }

    }
}
