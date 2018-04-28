using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Idea
    {
        [Required]
        public int id { set; get; }

        public Student leader { set; get; }
        public int leaderid { get; set; }

        [Required]
        [DisplayName("Idea Name")]
        public string name { set; get; }
        [Required]
        [DisplayName("Idea Description")]
        public string description { set; get; }
        [Required]
        [DisplayName("Tools")]
        public string tools { set; get; }

        [DisplayName("First Professor")]
        public Professor professor1 { get; set; }
        public int professor1id { get; set; }

        [DisplayName("Second Professor")]
        public Professor professor2 { get; set; }
        public int professor2id { get; set; }

        [DisplayName("Third Professor")]
        public Professor professor3 { get; set; }
        public int professor3id { get; set; }

        public int isApproved { set; get; }
    }
}