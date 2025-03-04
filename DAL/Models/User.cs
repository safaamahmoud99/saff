﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("User")]
    public class User:IdentityUser
    {
        [Required]
        public override string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare ("Password")]
        public string confirmPassword { get; set; }

        public string Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
