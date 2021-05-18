using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training_ProgramMuscles
    /*
    <Trainig Program> / <Trainee Tab> and <Muscles> connection object cotaining:
                    1. id
                    2. training progrem / trainee tab id list
                    3. muscles id list
    */
    {
        public int id { get; set; }
        public Training_Program training_Program{ get; set; }
        public int training_ProgramId{ get; set; } // client's tab id
        public Muscle muscles { get; set; }
        public int musclesId { get; set; } // muscle id
    }
}
