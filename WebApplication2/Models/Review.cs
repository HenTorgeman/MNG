using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Review
    /*
    Review object cotaining:
                    1. id
                    2. trainee's note on the training
                    3. coach's note on the training
    */
    {
        public Review(string trainee_note)
        {
            this.trainee_note = trainee_note;
        }
        public Review(string trainee_note,string coach_note)
        {
            this.trainee_note = trainee_note;
            this.coach_note = coach_note;
        }
        public int id { get; set; }
        public string trainee_note { get; set; }
        public string coach_note { get; set; }

    }
}
