using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
    }
}
