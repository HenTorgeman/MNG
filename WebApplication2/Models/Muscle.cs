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
            categoryId = Int32.Parse(dr.Field<string>("CategoryId"));
            exerciseMuscles = new List<Exercise_Muscle>();
            training_Programs = new List<Training_Program>();

        }
        public int id { get; set; }
        public string name { get; set; }
        public string HebrewName { get; set; }
        public List<Exercise_Muscle> exerciseMuscles { get; set; }
        public virtual List<Training_Program> training_Programs { get; set; }
        public int categoryId { get; set; }
        public virtual Category category { get; set; }


    }
}
