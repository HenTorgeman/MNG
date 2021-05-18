using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Exercise_Trainee
    /*
    <Exercise> and <Trainee> connection object cotaining:
                    1. id
                    2. training progrem / trainee tab id list
                    3. muscles id list
    */
    {
        public int id { get; set; }

        public int exerciseId { get; set; } // exercise id
        public Exercise exercise { get; set; } // maybe not needed ?
        
        public int trainingId { get; set; } //training id
        public Training training { get; set; } // maybe not needed ?
        public int repets { get; set; } // repeats, number of repeats per set
        public double max_wight{ get; set; }
        public double rpg{ get; set; } // ?
        public double parameter1 { get; set; }
        public double parameter2 { get; set; }
        public Score score { get; set; } // performance of the client in the training, idk if needed here, maybe DB reasons?
        public Review review { get; set; } // review of the client in the training, idk if needed here, maybe DB reasons?

    }
}
