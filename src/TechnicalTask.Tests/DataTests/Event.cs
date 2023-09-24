using System;
using System.Linq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;
using System.Collections.Generic;

namespace TechnicalTask.Tests.DataTests
{
    public class Event
    {
        private DataContext db;
        [SetUp]
        public void Setup()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<DataContext>().UseNpgsql(Config.ConnectionString);
            db = new DataContext(dbContextBuilder.Options);
            db.Database.EnsureCreated();
        }
        [Test]
        public void FetchEventRecord_GivenNewEventRecordCreated_ShouldReturnAddedRecord()
        {
            try
            {
                /* Prepare */
                var attendees =new  List<Data.Entities.Attendee>();
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                var event1 = Utility.CreateEvent(attendees);

                /* Act */
                db.Event.Add(event1);
                db.SaveChanges();
                db.Attach(event1);
                var results = db.Event.Where(f => f.Id == event1.Id).ToList();


                /* Asserts */
                Assert.IsTrue(results[0].EventUUId.Equals(event1.EventUUId), $"Mismatch in EventUUIds .");
                Assert.IsTrue(results[0].Title.Equals(event1.Title), $"Mismatch in Event Titles .");
                Assert.IsTrue(results[0].Description.Equals(event1.Description), $"Mismatch in Descriptions .");
                Assert.IsTrue(results[0].StartTime.Equals(event1.StartTime), $"Mismatch in StartTimes .");
                Assert.IsTrue(results[0].EndTime.Equals(event1.EndTime), $"Mismatch in EndTimes .");
                Assert.IsTrue(results[0].Attendees.Equals(event1.Attendees), $"Mismatch in Attendees .");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to insert new Event record to the Event table. Exception was thrown. {ex}");
            }
        }

        [Test]
        public void UpdateEventRecord_GivenNewEventRecordCreated_ShouldReturnUpdatedRecord()
        {
            try
            {
                /* Prepare */
                var attendees = new List<Data.Entities.Attendee>();
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                var event1 = Utility.CreateEvent(attendees);
                var update_event1 = Utility.CreateEvent(attendees);

                /* Act */

                db.Event.Add(event1);
                db.SaveChanges();
                db.Attach(event1);

                var row = db.Event.FirstOrDefault(f => f.Id == event1.Id);
                if (row != null)
                {
                    row.Title = update_event1.Title;
                    row.Description = update_event1.Description;
                    row.StartTime = update_event1.StartTime;
                    row.EndTime = update_event1.EndTime;
                    db.SaveChanges();
                }

                var results = db.Event.Where(f => f.Id == event1.Id).ToList();
                /* Asserts */
                Assert.IsTrue(results[0].Title.Equals(update_event1.Title), $"Mismatch in Event Titles .");
                Assert.IsTrue(results[0].Description.Equals(update_event1.Description), $"Mismatch in Descriptions .");
                Assert.IsTrue(results[0].StartTime.Equals(update_event1.StartTime), $"Mismatch in StartTimes .");
                Assert.IsTrue(results[0].EndTime.Equals(update_event1.EndTime), $"Mismatch in EndTimes .");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to update a Event record to the Event table. Exception was thrown. {ex}");
            }
        }

        [Test]
        public void DeleteEventRecord_GivenNewEventRecordCreated_ShouldReturnEmptyRecord()
        {
            try
            {
                /* Prepare */
                var attendees = new List<Data.Entities.Attendee>();
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                attendees.Add(Utility.CreateAttendee());
                var event1 = Utility.CreateEvent(attendees);

                /* Act */
                db.Event.Add(event1);
                db.SaveChanges();
                db.Attach(event1);

                var row = db.Event.FirstOrDefault(f => f.Id == event1.Id);
                if (row != null)
                {
                    db.Remove(row);
                    db.SaveChanges();
                }
                var results = db.Event.Where(f => f.Id == event1.Id).ToList();


                /* Asserts */
                Assert.IsEmpty(results, $"Expected to find an empty list in results.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to delete a Event record in the Event table. Exception was thrown. {ex}");
            }
        }

    }
}
