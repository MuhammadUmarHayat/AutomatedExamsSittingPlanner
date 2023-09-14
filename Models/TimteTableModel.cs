using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_Planner.Models
{
    public class TimteTableModel
    {
        //EmpName, EmpId, RoomNo,Date,Time,Status
        [Display(Name = "Time Table Code")]
        public string ID { get; set; }
        [Display(Name = "Faculty Member Name")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Faculty Member ID is required.")]
        [Display(Name = "Faculty Member ID")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Room No is required.")]
        public string RoomNo { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        public string Time { get; set; }
             
        public string Status { get; set; }
       
    }
}