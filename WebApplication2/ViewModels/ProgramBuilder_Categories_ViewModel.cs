using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.ViewModels
{
    public class ProgramBuilder_Categories_ViewModel
    {
        public ProgramBuilder_Categories_ViewModel()
        {

        }
        public ProgramBuilder_Categories_ViewModel(int trainee_id)
        {
            this.traineeId = trainee_id;

        }

        public int traineeId { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public List<int> selected_categories { get; set; }
        public IEnumerable<Muscle> muscles{ get; set; }
        public List<int> selected_Muscles { get; set; }
       

    }
}
