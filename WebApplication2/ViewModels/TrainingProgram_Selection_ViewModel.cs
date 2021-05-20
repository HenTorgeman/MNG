using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.ViewModels
{
    public class TrainingProgram_Selection_ViewModel
    {

        public TrainingProgram_Selection_ViewModel() { }
        public int traineeId{ get; set; }
        public int duration { get; set; }
        public int diffrent_training_number { get; set; }
        public Program_type type{ get; set; }
        public enum Program_type
        {
            Categories,
            Costomize,
            Template

        }
    }
}
