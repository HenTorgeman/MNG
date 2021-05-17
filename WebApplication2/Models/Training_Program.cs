using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training_Program
    {
         //Duration
        public int id { get; set; }
        public string name { get; set; }
        public int traineeId { get; set; }
        public virtual Trainee trainee{ get; set; }
        public virtual List<Training> trainings{ get; set; }
        public virtual List<Muscle> muscles{ get; set; }
        
    }
}
