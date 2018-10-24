using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cars.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZIP { get; set; }

    }
}
