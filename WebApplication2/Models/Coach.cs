using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Coach:User
    /*
    Coach object cotaining:
                    1. id
                    2. english name
                    3. training list of training he conducted
    */
    {
        public List<Training> trainings{ get; set; } 
    }
}
