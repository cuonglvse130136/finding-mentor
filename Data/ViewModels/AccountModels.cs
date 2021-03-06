using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.ViewModels
{
    public class LoginModel
    {
        public string IdToken { get; set; }
 
    }

    public class LoginSuccessModel
    {
        public string Fullname { get; set; }
        public object Token { get; set; }
        public List<string> Roles { get; set; }

        public string UserId { get; set; }

         
    }

    public class UserRegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Gender { get; set; }

        public string Uid { get; set; }

        public string MajorId { get; set; }
        

    }

    public class UserAuthModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string IdToken { get; set; }

    }

    public class AdminLoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
