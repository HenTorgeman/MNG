using System;
using System.Collections.Generic;
using System.Data;
using PersonalTrainerApp.Data;


namespace PersonalTrainerApp.Models
{
    public class Exercise_Muscle
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
        public Muscle muscle{ get; set; } 
        public int exerciseId { get; set; }
        public Exercise exercise { get; set; }
    }
}                                           
