using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_Planner.Models
{
    public class RoomModel
    {
        [Display(Name = "Room Code")]
        public int RoomNo { get; set; }
        [Required(ErrorMessage = "Floor is required.")]
        public string Floor { get; set; }
        [Required(ErrorMessage = "Capacity is required.")]
        public int Capacity { get; set; }
    }
}