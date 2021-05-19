using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Exercise
    /*
     Exercise object cotaining:
                        1. id
                        2. english name
                        3. hebrew name
                        4. max/min weight possible (available weights in the gym)
                        5. connection objects (DB reasons)
     */
    // maybe add another class of 'Set' cotaining number of repeats and stuff like that instead of in the connector, that way its more generic
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
            exercise_Muscles = new List<Exercise_Muscle>();
            exercise_Trainees = new List<Exercise_Trainee>();

        }

        public int id { get; set; }

        public string name { get; set; }
        public string HebrewName { get; set; }
        public double max_whight { get; set; } // max_weight
        public double min_whight { get; set; } //  min_weight
        public List<Exercise_Muscle> exercise_Muscles { get; set; } // connection object between an exercise and a muscle (DB)
        public virtual List<Exercise_Trainee> exercise_Trainees { get; set; } // connection object between an exercise and a trainee (DB)

    }
}
