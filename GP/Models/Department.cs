using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Department
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public IEnumerable<Department> Departments()
        {
            Department d1 = new Department();
            d1.id = 1;
            d1.name = "CS";

            Department d2 = new Department();
            d2.id = 2;
            d2.name = "IS";

            Department d3 = new Department();
            d3.id = 3;
            d3.name = "IT";

            Department d4 = new Department();
            d4.id = 4;
            d4.name = "SW";

            List<Department> Departments = new List<Department>();
            Departments.Add(d1);
            Departments.Add(d2);
            Departments.Add(d3);
            Departments.Add(d4);

            return Departments; 
        }
    }
}