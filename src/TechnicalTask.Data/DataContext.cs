
using Microsoft.EntityFrameworkCore;
using System;
using TechnicalTask.Data.Entities;

namespace TechnicalTask.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext()
        {

            this.connectionString = "";

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Attendee> Attendee { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            if (!optionsBuilder.IsConfigured)
            {
                if (!String.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseNpgsql(this.connectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "dbo"));
                }
                else
                    base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
