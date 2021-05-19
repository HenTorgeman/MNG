using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Performance
    //Should be 'Progress' - תהליך, התקדמות. 
    //Performance זה ביצועים, אולי עדיף להחליף את 
    // Score-> Performance
    // Performance -> Progress
    //
    /*
    Performance object cotaining:
                    1. id
                    2. trainee id
                    3. image link for the relevant training
                    4. weight record history
                    5. exercises 
    */
    {
        public Performance()
        {
            weight_progress = new List<double>();
            exercises_progress = new List<Exercise>();
        }


    

    public Performance(int traineeId)
        {
            datetime = DateTime.Now.Date;
            this.traineeId = traineeId;
            weight_progress = new List<double>();
            exercises_progress = new List<Exercise>();
        }
        public Performance(int traineeId, string url)
        {
            datetime = DateTime.Now.Date;
            traineeId = trainee.id;
            img_url = url;
            weight_progress = new List<double>();
            exercises_progress = new List<Exercise>();

        }
        [Key]
        public int id { get; set; }
        [Required]
        public int traineeId { get; set; }
        [Required]
        public DateTime datetime { get; set; } // date
        public Trainee trainee { get; set; } // Trainee OBJECT (we can use traineeId to get this Trainee, maybe un-neccassary)
        public string img_url { get; set; } // post-workout image  

        //For calculate Methides- Not related to the DB
        [NotMapped]
        public List<double> weight_progress { get; set; } // progress of weight (mass of body)
        [NotMapped]
        public List<Exercise> exercises_progress { get; set; } // List of exercises checked, here we can also get a list of ID's and fetch the exercise when needed to ease on loading of db

    }

}
