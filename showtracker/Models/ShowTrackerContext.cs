using Microsoft.EntityFrameworkCore;

namespace ShowTracker.Models
{
    public class ShowTrackerContext : DbContext
    {
        public ShowTrackerContext(DbContextOptions<ShowTrackerContext> options) : base(options) { }

        public DbSet<Show> Shows { get; set; }
    }
}
