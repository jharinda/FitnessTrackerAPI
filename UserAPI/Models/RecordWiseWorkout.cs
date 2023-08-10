using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class RecordWiseWorkout
    {
        [Key]
        public int Id { get; set; }
        public int RecordId { get; set; }
        public int WorkoutId { get; set; }
        public int Reps { get; set; }
    }
}
