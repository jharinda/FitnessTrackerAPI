using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models.ViewModels
{
    public class ViewModelRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public List<RecordWiseMeal> RecordWiseMeals { get; set; }
        public List<RecordWiseWorkout> RecordWiseWorkouts { get; set; }
    }
}
