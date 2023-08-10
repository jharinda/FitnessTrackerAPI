using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class RecordWiseMeal
    {
        [Key]
        public int Id { get; set; }
        public int RecordId { get; set; }
        public int MealId { get; set; }
        public int MealQuantity { get; set; }
    }
}
