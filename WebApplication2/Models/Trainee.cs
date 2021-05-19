using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Trainee : User
    /*
    Trainee object cotaining:
                    1. subscription date
                    2. progress of the client
                    3. review
                    4. client's training program history
    */
    {
        public DateTime subscribe_date{ get; set; } // date joined
        public List<Performance> performances{ get; set; } // List of 'Progress' objects to later check stats 
        public virtual Review review{ get; set; } // why do we need review here if they do after training? if he starts on join a training it will be in there and if not no need for review
        public List<Training_Program> training_Programs { get; set; } // all client's history of training programs

    }
}
