﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Bases;
using UserManagement.Models;

namespace UserManagement.Microservices.Models
{
    [Table("TB_M_User")]
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsUpdatePassword { get; set; }
        public Employee Employee { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }
    }
}
