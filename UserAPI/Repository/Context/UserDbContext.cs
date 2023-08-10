using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordWiseMeal> RecordWiseMeals { get; set; }
        public DbSet<RecordWiseWorkout> RecordWiseWorkouts { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

    }
}
