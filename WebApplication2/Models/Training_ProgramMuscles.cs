using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training_ProgramMuscles
    {
        public int id { get; set; }
        public Training_Program training_Program{ get; set; }
        public int training_ProgramId{ get; set; }
        public Muscle muscles { get; set; }
        public int musclesId { get; set; }
    }
}
