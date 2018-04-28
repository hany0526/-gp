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
    public class Student 
    {
        [Required]
        [DisplayName("ID")]
        public int id { set; get; }

        [Required]
        public int type { set; get; }

        [Required]
        [DisplayName("Name")]
        public string name { set; get; }

        [Required]
        [DisplayName("Email")]
        public string email { set; get; }

        [Required]
        [MinLength(5)]
        public string password { set; get; }

        public Department Department { get; set; }
        public int Departmentid { get; set; }

        [Required]
        public int level { set; get; }

        [Required]
        public double GPA { set; get; }

        [Required]
        public string skills { set; get; }

        public int phone { get; set; }

        public Student leader { get; set; }
        public int leaderid { set; get; }

        public byte[] file { get; set; }

    }
}