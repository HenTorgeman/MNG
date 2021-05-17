using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Trainee : User
    {
        public DateTime subscribe_date{ get; set; }
        public List<Performance> performances{ get; set; }
        public virtual Review review{ get; set; } 
        public List<Training_Program> training_Programs { get; set; }

    }
}
