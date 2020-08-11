using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data.Entities;
using WorkoutApi.Data.Mappings;

namespace WorkoutApi.Data
{
    public class WorkoutApiDbContext : DbContext
    {
        public DbSet<WorkoutEntity> Workouts { get; set;}

        //Required by DB Context to get apply options with options builder at start up
        public WorkoutApiDbContext(DbContextOptions<WorkoutApiDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkoutMapping());//TODO : right place and order ?
            builder.ApplyConfigurationsFromAssembly(typeof(WorkoutApiDbContext).Assembly);
        }
    }
}
