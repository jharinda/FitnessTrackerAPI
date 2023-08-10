using Microsoft.EntityFrameworkCore;
using WorkoutsAPI.Models;

namespace WorkoutsAPI.Repository
{
    public class WorkoutsDbContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }

        public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Workout>()
        //        .Property(b => b.Id)
        //        .HasDefaultValue(-1);
        //}

    }
}
