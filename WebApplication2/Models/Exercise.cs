using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Exercise
    {
        public Exercise()
        {
            this.name = "";
            this.HebrewName ="";
        }
        public Exercise(string name,string HebrewName)
        {
            this.name = name;
            this.HebrewName = HebrewName;            
        }
        public Exercise(DataRow dr)
        {

            name = dr.Field<string>("Exercsis_Name");
            HebrewName = dr.Field<string>("Exercsis_HebrewName");
            exerciseMuscles = new List<Exercise_Muscle>();
            exercise_Trainees = new List<Exercise_Trainee>();

        }

        public int id { get; set; }

        public string name { get; set; }
        public string HebrewName { get; set; }
        public double max_whight { get; set; }
        public double min_whight { get; set; }
        public List<Exercise_Muscle> exerciseMuscles { get; set; }
        public virtual List<Exercise_Trainee> exercise_Trainees { get; set; }

    }
}
