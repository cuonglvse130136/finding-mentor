using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;

namespace Data.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public double Balance { get; set; }

        public string MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

      

        public static ClaimsIdentity Identity { get; internal set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
