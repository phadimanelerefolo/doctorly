using System;
using System.Linq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Data;

namespace TechnicalTask.Tests.DataTests
{
    public class Attendee
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
        public void FetchAttendeeRecord_GivenNewAttendeeRecordCreated_ShouldReturnAddedRecord()
        {
            try
            {
                /* Prepare */
                var attendee = Utility.CreateAttendee();

                /* Act */
                db.Attendee.Add(attendee);
                db.SaveChanges();
                db.Attach(attendee);
                var results = db.Attendee.Where(f => f.Id == attendee.Id).ToList();


                /* Asserts */
                Assert.IsTrue(results[0].Id.Equals(attendee.Id), $"Mismatch in  Ids .");
                Assert.IsTrue(results[0].AttendeeUUId.Equals(attendee.AttendeeUUId), $"Mismatch in AttendeeUUIds .");
                Assert.IsTrue(results[0].Name.Equals(attendee.Name), $"Mismatch in Attendee Names .");
                Assert.IsTrue(results[0].EmailAddress.Equals(attendee.EmailAddress), $"Mismatch in EmailAddress's .");
                Assert.IsTrue(results[0].Attending.Equals(attendee.Attending), $"Mismatch in Attending values .");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to insert new Attendee record to the Attendee table. Exception was thrown. {ex}");
            }
        }

        [Test]
        public void UpdateAttendeeRecord_GivenNewAttendeeRecordCreated_ShouldReturnUpdatedRecord()
        {
            try
            {
                /* Prepare */
                var attendee = Utility.CreateAttendee();
                var update_attendee = Utility.CreateAttendee();

                /* Act */

                db.Attendee.Add(attendee);
                db.SaveChanges();
                db.Attach(attendee);

                var row = db.Attendee.FirstOrDefault(f => f.Id == attendee.Id);
                if (row != null)
                {
                    row.Name = update_attendee.Name;
                    row.EmailAddress = update_attendee.EmailAddress;
                    row.Attending = update_attendee.Attending;
                    db.SaveChanges();
                }

                var results = db.Attendee.Where(f => f.Id == attendee.Id).ToList();
                /* Asserts */
                Assert.IsTrue(results[0].Name.Equals(update_attendee.Name), $"Mismatch in Attendee Names .");
                Assert.IsTrue(results[0].EmailAddress.Equals(update_attendee.EmailAddress), $"Mismatch in EmailAddress's .");
                Assert.IsTrue(results[0].Attending.Equals(update_attendee.Attending), $"Mismatch in Attending values .");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to update a Attendee record to the Attendee table. Exception was thrown. {ex}");
            }
        }

        [Test]
        public void DeleteAttendeeRecord_GivenNewAttendeeRecordCreated_ShouldReturnEmptyRecord()
        {
            try
            {
                /* Prepare */
                var attendee = Utility.CreateAttendee();

                /* Act */
                db.Attendee.Add(attendee);
                db.SaveChanges();
                db.Attach(attendee);

                var row = db.Attendee.FirstOrDefault(f => f.Id == attendee.Id);
                if (row != null)
                {
                    db.Remove(row);
                    db.SaveChanges();
                }
                var results = db.Attendee.Where(f => f.Id == attendee.Id).ToList();


                /* Asserts */
                Assert.IsEmpty(results, $"Expected to find an empty list in results.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to delete a Attendee record in the Attendee table. Exception was thrown. {ex}");
            }
        }

    }
}
