using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerApp.Models
{
    public class Category
    {
        public Category()
        {
            this.name = "";
            this.hebrewName = "";
            muscles = new List<Muscle>();

        }
        public Category(string name, string HebrewName)
        {
            this.name = name;
            this.hebrewName = HebrewName;
            muscles = new List<Muscle>();

        }
        public Category(DataRow dr)
        { 
            name = dr.Field<string>("Categorys_Name");
            hebrewName = dr.Field<string>("Categorys_HebrewName");
            muscles = new List<Muscle>();
        }
        public int id { get; set; }
        public string name{ get; set; }
        public string hebrewName { get; set; }
        public virtual List<Muscle> muscles { get; set; }
    }
}
