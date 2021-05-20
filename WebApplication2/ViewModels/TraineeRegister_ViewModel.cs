using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.ViewModels
{
    public class TraineeRegister_ViewModel
    {
        public TraineeRegister_ViewModel()
        {
        }
        public int traineeId { get; set; }
        public string reviewTrainee{ get; set; }
        public string reviewCoach { get; set; }
        public string img_name { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile img_file { get; set; }
      //  public Performance performance { get; set; }
    }                                                          
}
