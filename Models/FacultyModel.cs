using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Models
{
    public class FacultyModel
    {

        [Required(ErrorMessage = "Employee No is required.")]
        public string EmpID { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        public string Full_name { get; set; }

        public string Password { get; set; }

        public string Designation { get; set; }
        public string Date_Of_Appointment { get; set; }
        public string Status { get; set; }
        public string Emp_type { get; set; }
        public string Address { get; set; }

    }
}