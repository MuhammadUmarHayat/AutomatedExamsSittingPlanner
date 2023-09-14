using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_Planner.Models
{
    public class StudentModel
    {
        [Display(Name = "RegistrationNo")]
       public string Studentid { get; set; }
        [Required(ErrorMessage = "Full name is required.")]
        public string Name { get; set; }
        public string Program { get; set; }
        public string Rollnumber { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
}