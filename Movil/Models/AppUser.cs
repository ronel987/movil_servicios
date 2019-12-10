using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class AppUser: IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public ICollection<Course> courses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        
        public virtual ICollection<Order> TeacherOrders { get; set; }
    }

    public class AppUserRole : IdentityRole {

        public string code { get; set; }
    }
}
