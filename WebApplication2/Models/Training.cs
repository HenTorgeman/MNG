using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training
    /*
    Training object cotaining:
                    1. id
                    2. date and time of start
                    3. the coach conducted the training
                    4. client's tab
                    5. connection objects (DB reasons)
                    6. Score / Performance and Review for the train
    */
    {
        public int id{ get; set; }
        public DateTime date{ get; set; } // date of start
        public DateTime time{ get; set; } // time of start 

        public int coachId { get; set; } // coach conducted training
        public virtual Coach coach { get; set; } // here also maybe we can fetch after loadup
        public int training_programId { get; set; } // client's tab id
        public virtual Training_Program training_program { get; set; } // here also maybe we can fetch after loadup
        public virtual List<Exercise_Trainee> exercise_trainees { get; set; } // connection object between an exercise and a trainee (DB)
        public Score score { get; set; } // today's Performance / Score
        public  Review review{ get; set; } // today's Review
    }
}
