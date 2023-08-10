using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutsAPI.Models;
using WorkoutsAPI.Repository;

namespace WorkoutsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private ILogger<WorkoutsController> _logger;
        private WorkoutsDbContext _context;

        public WorkoutsController(ILogger<WorkoutsController> logger, WorkoutsDbContext applicationDbContext)
        {
            _logger = logger;
            _context = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<Workout> Get()
        {
            return _context.Workouts.ToArray();
        }
    }
}
