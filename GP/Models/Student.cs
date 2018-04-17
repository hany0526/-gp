using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Student //: DbContext
    {
        //public DbSet<Student> Students { set; get; }

        [Required]
        [DisplayName("ID")]
        public int id { set; get; }

        [Required]
        public int type { set; get; }

        [Required]
        public string name { set; get; }

        [Required]
        public string email { set; get; }

        [Required]
        [MinLength(5)]
        public string password { set; get; }

        [Required]
        public int level { set; get; }

        [Required]
        public double GPA { set; get; }

        [Required]
        public string skills { set; get; }

        
        public int leader_id { set; get; }

    }
}