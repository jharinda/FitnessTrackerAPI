using MealsAPI.Models;
using MealsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private ILogger<MealsController> _logger;
        private MealDbContext _context;

        public MealsController(ILogger<MealsController> logger, MealDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            return _context.Meals.ToArray();
        }
    }
}
