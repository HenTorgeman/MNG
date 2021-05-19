using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Muscle
    /*
	change change change change change
    Exercise object cotaining:
                    1. id
                    2. name
                    3. hebrew name
                    4. client's tab
                    5. muscle's category
                    6. connection objects (DB reasons)
    */
    {
        public Muscle()
        {
            this.name = "";
            this.HebrewName = "";
        }
        public Muscle(string name, string HebrewName)
        {
            this.name = name;
            this.HebrewName = HebrewName;
        }
        public Muscle(DataRow dr)
        {

            name = dr.Field<string>("Muscles_Name");
            HebrewName = dr.Field<string>("Muscles_HebrewName");
            int id = Int32.Parse(dr.Field<string>("Category"));
            category = (Category)id;
            exerciseMuscles = new List<Exercise_Muscle>();
            training_Programs = new List<Training_Program>();

        }
        public int id{ get; set; }
        public string name{ get; set; }
        public string HebrewName { get; set; }
        public List<Exercise_Muscle> exerciseMuscles { get; set; } // object to connect between an exercise and a muscle (DB)
        public virtual List<Training_Program> training_Programs{ get; set; } // a Tab for each trainee containing the exercises in the program and the duration till its ended
        // is it needed here for db? if not, i can't see a reason for muscle to have a list of training programs
        public Category category{ get; set; } // maybe add another enum like this with upper and lower body only to filter even more
    }

    public enum Category
    {
         Toroso,
         Legs,
         Back,
         Buttock
    }
}
