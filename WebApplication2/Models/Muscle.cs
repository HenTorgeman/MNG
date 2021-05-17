using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Muscle
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
        public List<Exercise_Muscle> exerciseMuscles { get; set; }
        public virtual List<Training_Program> training_Programs{ get; set; }
        public Category category{ get; set; }
    }

    public enum Category
    {
         Toroso,
         Legs,
         Back,
         Buttock
    }
}
