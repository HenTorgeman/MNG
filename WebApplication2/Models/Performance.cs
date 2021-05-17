using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Performance
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
        public DateTime datetime { get; set; }// רשימת תאריכי דגימה
        public Trainee trainee { get; set; }
        public string img_url { get; set; }//תמונות 

        //For calculate Methides- Not related to the DB
        [NotMapped]
        public List<double> weight_progress { get; set; }//פערי משקל בין התרגילים
        [NotMapped]
        public List<Exercise> exercises_progress { get; set; }//רשימת התרגילים שנבדקו

    }

}
