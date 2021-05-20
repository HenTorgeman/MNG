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
        public Performance(int traineeId, string img_name, string img_url)
        {
            datetime = DateTime.Now.Date;
            traineeId = trainee.id;
            this.img_url = img_url;
            this.img_name = img_name;
            weight_progress = new List<double>();
            exercises_progress = new List<Exercise>();

        }


        [Key]
        public int id { get; set; }
        [Required]
        public int traineeId { get; set; }
        [Required]
        public DateTime datetime { get; set; }
        public Trainee trainee { get; set; }

        public string img_name { get; set; }
        public string img_url { get; set; }

        //[NotMapped]
        //[DisplayName("UploadFile")]
        //public IFormFile img { get; set; }

        //For calculate Methides- Not related to the DB
        [NotMapped]
        public List<double> weight_progress { get; set; }//פערי משקל בין התרגילים
        [NotMapped]
        public List<Exercise> exercises_progress { get; set; }//רשימת התרגילים שנבדקו

    }
}
