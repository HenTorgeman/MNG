
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;

        namespace PersonalTrainerApp.Models
        {

    public class User
    /*
    User object cotaining:
                    1. id
                    2. name
                    3. phone
                    4. user's role (Admin / Coach / Trainee)
    */
    {
        public int id { get; set; }    
        public string name { get; set; }
        //  public string password{ get; set; }
        public string phone { get; set; }

        public UserRole role { get; set; } = UserRole.Trainee; //   Admin / Coach / Trainee
    }

    public enum UserRole
    {
        Admin =0,
        Coach=1,
        Trainee=2
    }
    
}
          