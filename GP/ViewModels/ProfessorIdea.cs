using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class ProfessorIdea
    {
        public  Idea Idea { get; set; }
        public  List<Professor> Professors { get; set; }

    }
}