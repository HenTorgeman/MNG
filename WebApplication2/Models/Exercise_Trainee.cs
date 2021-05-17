using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Exercise_Trainee 
    {
        public int id { get; set; }

        public int exerciseId { get; set; }
        public Exercise exercise { get; set; }
        
        public int trainingId { get; set; }
        public Training training{ get; set; }        
        public int repets { get; set; }
        public double max_wight{ get; set; }
        public double rpg{ get; set; }
        public double parameter1 { get; set; }
        public double parameter2 { get; set; }
        public Score score { get; set; }
        public Review review { get; set; }

    }
}
