using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models

{
    public class Score
    /*
    Score / Performance object cotaining:
                    1. id
                    2. date
                    3. trainee's rating of the coach (1-10)
                    4. coach's rating of the trainee (1-10)
    */
    //better call it performance probably
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int trainee_score { get; set; }     //(1-10) 1 is easy 10 is most hard.
        public int coach_score { get; set; }
    }
}
