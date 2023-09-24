using System;
using System.Collections.Generic;
using TechnicalTask.Data;
using TechnicalTask.Data.Entities;

namespace TechnicalTask.Tests
{
    public class Utility
    {
        public static Attendee CreateAttendee()
        {
            var timestamp = DateTime.UtcNow;
            return new Attendee
            {
                Name = timestamp.AddSeconds(10).Ticks.ToString(),
                AttendeeUUId = Guid.NewGuid(),
                EmailAddress = timestamp.AddSeconds(20).Ticks.ToString(),
                Attending = true
            };
        }

        public static Attendee AddAttendee(DataContext db)
        {
            var attendee= CreateAttendee();
            db.Add(attendee);
            db.SaveChanges();
            db.Attendee.Attach(attendee);
            return attendee;
        }

        public static Event CreateEvent(List<Attendee> attendees)
        {
            var timestamp = DateTime.UtcNow;
            return new Event
            {
                EventUUId = Guid.NewGuid(),
                Title = timestamp.AddSeconds(10).Ticks.ToString(),
                Description = timestamp.AddSeconds(20).Ticks.ToString(),
                Attendees = attendees,
                StartTime = timestamp.AddDays(1),
                EndTime = timestamp.AddDays(2)
            };
        }

        public static Event AddEvent(List<Attendee> attendees,DataContext db)
        {
            var event1= CreateEvent(attendees);
            db.Add(event1);
            db.SaveChanges();
            db.Event.Attach(event1);
            return event1;
        }
    }
}
