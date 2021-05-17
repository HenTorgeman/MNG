using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.ViewModels
{
    public class TraineeRegister_Muscles_ViewModel
    {
        public TraineeRegister_Muscles_ViewModel()
        {
        
        }
        public TraineeRegister_Muscles_ViewModel(int traineeId, IEnumerable<Muscle> QueryMuscles)
        {
            this.traineeId =traineeId;
            this.muscles = QueryMuscles;
            selectedMuscles = new List<Muscle>();
        }
        public int traineeId { get; set; }
        public IEnumerable<Muscle> muscles { get; set; }
        public List<Muscle> selectedMuscles { get; set; }
    }
}
