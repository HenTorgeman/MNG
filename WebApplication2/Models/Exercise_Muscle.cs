using System;
using System.Collections.Generic;
using System.Data;
using PersonalTrainerApp.Data;


namespace PersonalTrainerApp.Models
{
    public class Exercise_Muscle
    /*
    <Exercise> and <Muscle> connection object cotaining:
                1. id
                2. exercise id list
                3. muscles id list
    */
    {
        public Exercise_Muscle(int muscleId, int exerciseId)
        {
            this.muscleId  =muscleId;
            this.exerciseId = exerciseId;
        }
        public Exercise_Muscle(DataRow dr)
        {
            this.muscleId  = Int32.Parse(dr.Field<string>("Muscles_Id")); 
            this.exerciseId = Int32.Parse(dr.Field<string>("Exercsis_Id"));

        }
        public int id{ get; set; }
        public int muscleId { get; set; }
        public Muscle muscle{ get; set; } // here also maybe its better to fetch muscle object when needed to ease lodaing time if possible
        public int exerciseId { get; set; }
        public Exercise exercise { get; set; } // here also maybe its better to fetch exercise object when needed to ease lodaing time if possible 
    }
}                                           
