using MealsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsAPI.Repository
{
    public class MealDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }

        public MealDbContext(DbContextOptions<MealDbContext> options) : base(options)
        {}
    }
}
