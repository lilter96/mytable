using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace User_table.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.RegistrationDate = DateTime.UtcNow.ToLongTimeString();
            this.LastLoginDate = DateTime.UtcNow.ToLongTimeString();
            this.IsBlocked = false;
        }
        [Required]
        public override string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string LastLoginDate { get; set; }

        [Required]
        public bool IsBlocked { get; set; }
    }
}
