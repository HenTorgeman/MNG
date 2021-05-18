using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Training_Program
    // Maybe better call it "Trainee_Tab" 
    // and then inside of it we'll have an enum of objects (if possible) with templates of programs, and then tehy can choose to do it manually or with set program
    // such as Full-Body, AB, ABC etc.
    /*
    Training_Program / Trainee_Tab object cotaining:
                    1. id
                    2. name
                    3. trainee id
                    4. list of trainings of the relevant tab
                    5. list of muscles applied work on
    */
    {
        //Duration
        public int id { get; set; }
        public string name { get; set; } // Of program (?)
        public int traineeId { get; set; } 
        public virtual Trainee trainee{ get; set; } // here also maybe its better to fetch trainee object when needed to ease lodaing time if possible
        public virtual List<Training> trainings{ get; set; } // same (take only id's and fetch when needed if possible)
        public virtual List<Muscle> muscles{ get; set; } // List of muscles wanted to work on by client. same (take only id's and fetch when needed if possible).

    }
}
