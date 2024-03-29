﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.IO;
using System.Web.Security;

namespace Definco.Models
{
        [Table("UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
            public string Address { get; set; }
            public string Cellphone { get; set; }
            public int SecurityLevel { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        public class RegisterExternalLoginModel
        {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            public string ExternalLoginData { get; set; }
        }

        public class LocalPasswordModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        }

        public class LoginModel
        {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Voornaam")]
            public string FirstName { get; set; }

            [Display(Name = "Achternaam")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Adres")]
            public string Address { get; set; }

            [Display(Name = "GSM")]
            public string Cellphone { get; set; }


        }

        public class ManageModel
        {
            public int UserId { get; set; }

            [Display(Name = "SecurityLevel")]
            public int SecurityLevel { get; set; }

            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Voornaam")]
            public string FirstName { get; set; }

            [Display(Name = "Achternaam")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Adres")]
            public string Address { get; set; }

            [Display(Name = "GSM")]
            public string Cellphone { get; set; }

            [Display(Name = "Datum creatie")]
            public DateTime CreatedDate { get; set; }

            public FileInfo[] files = new FileInfo[0];
        }

        public class ExternalLogin
        {
            public string Provider { get; set; }
            public string ProviderDisplayName { get; set; }
            public string ProviderUserId { get; set; }
        }
    }
