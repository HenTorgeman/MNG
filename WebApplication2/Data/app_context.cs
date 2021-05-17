using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalTrainerApp.Models;

namespace PersonalTrainerApp.Data
{
    public class app_context : DbContext
    {
        public app_context(DbContextOptions<app_context> options)
            : base(options)
        {
        }
        public DbSet<PersonalTrainerApp.Models.Trainee> Trainee { get; set; }
        public DbSet<PersonalTrainerApp.Models.Training_Program> Training_Program { get; set; }
        public DbSet<PersonalTrainerApp.Models.Exercise> Exercise { get; set; }
        public DbSet<PersonalTrainerApp.Models.Training> Training { get; set; }
        public DbSet<PersonalTrainerApp.Models.Muscle> Muscles { get; set; }
        public DbSet<PersonalTrainerApp.Models.Coach> Coach { get; set; } 
        public DbSet<PersonalTrainerApp.Models.User> User { get; set; }
        public DbSet<PersonalTrainerApp.Models.Exercise_Muscle> Exercise_Muscle { get; set; }
        public DbSet<PersonalTrainerApp.Models.Review> Preformence { get; set; }

    }
}
