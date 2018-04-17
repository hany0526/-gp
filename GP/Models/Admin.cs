using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Admin //: DbContext
    {
        //public DbSet<Admin> Admins { set; get; }
        [Required]
        public int id { set; get; }
        [Required]
        public string name { set; get; }
        [Required]
        public string email { set; get; }

        [Required]
        [MinLength(5)]
        public string password { set; get; }
    }
}