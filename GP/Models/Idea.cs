using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Models.Models
{
    public class Idea 
    {
        [Required]
        public int id { set; get; }
        
        public Student leader { set; get; }
        [Required]
        public string name { set; get; }
        [Required]
        public string description { set; get; }
        [Required]
        public string tools { set; get; }
       
        public Professor professor_1 { get; set; }
        
        public Professor professor_2 { get; set; }
        
        public Professor professor_3 { get; set; }
        [Required]
        public int isApproved { set; get; }
    }
}