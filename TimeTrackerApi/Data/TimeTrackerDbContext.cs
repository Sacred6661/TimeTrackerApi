using Microsoft.EntityFrameworkCore;
using TimeTrackerApi.Data.Enteties;

namespace TimeTrackerApi.Data
{
    public class TimeTrackerDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }

        public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options) : base(options)
        {
        }

    }
}
