﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.ViewModels
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginSuccessModel
    {
        public string Role { get; set; }
        public string Fullname { get; set; }
        public object Token { get; set; }
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
    }
}