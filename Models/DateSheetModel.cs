using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_Planner.Models
{
    public class DateSheetModel
    {
       public int DateSheetID { get; set; }
        [Display(Name = "Student ID")]
        public string Studentid { get; set; }

        [Required(ErrorMessage = "Exam date is required.")]
        public DateTime ExamDate { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Exam starting time is required.")]
        public string ExTime { get; set; }

        [Required(ErrorMessage = "Room No  is required.")]
        public string RoomNo { get; set; }
        [Required(ErrorMessage = "Seat No  is required.")]
        public string SeatNo { get; set; }
    }
}