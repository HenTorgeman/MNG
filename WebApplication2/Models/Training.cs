using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training
    {
        public int id{ get; set; }
        public DateTime date{ get; set; }
        public DateTime time{ get; set; }

        public int coachId { get; set; }
        public virtual Coach coach { get; set; }
        public int training_programId { get; set; }
        public virtual Training_Program training_program { get; set; }
        public virtual List<Exercise_Trainee> exercise_trainees { get; set; }
        public Score score { get; set; }
        public  Review review{ get; set; }
    }
}
