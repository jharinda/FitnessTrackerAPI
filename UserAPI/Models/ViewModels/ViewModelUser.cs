using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models.ViewModels
{
    public class ViewModelUser
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public float HeightInCm { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ViewModelRecord> Records { get; set; }
    }
}
