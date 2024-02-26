using Microsoft.EntityFrameworkCore;

namespace MoviesManagement.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActivityRole> ActivityRoles { get; set; }
        public DbSet<AgeLimit> AgeLimits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<ProjectionActivity> ProjectionActivities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Technology> Technologies { get; set; }
    }
}
