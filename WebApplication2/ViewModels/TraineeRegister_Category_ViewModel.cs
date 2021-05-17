using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.ViewModels
{
    public class TraineeRegister_Category_ViewModel
    {
        public TraineeRegister_Category_ViewModel()
        {
        }
        public int traineeId { get; set; }
        public IEnumerable<Category> categorys { get; set; } = Enum.GetValues(typeof(Category)).Cast<Category>();
        public List<int> Selected_categorysId { get; set; }
        public string reviewValue{ get; set; }
        public string img{ get; set; }
      //  public Performance performance { get; set; }
    }                                                          
}
