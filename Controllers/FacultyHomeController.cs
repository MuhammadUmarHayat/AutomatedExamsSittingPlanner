using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.IO;
using System.Text;

namespace Exam_Planner.Controllers
{
    public class FacultyHomeController : Controller
    {
        DAL dal = new DAL();

        // GET: FacultyHome
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("Index");
            }
        }
        public ActionResult ViewTimeTable()
        {
            var dt = dal.TimeTableList();
            List<TimteTableModel> timetableList = new List<TimteTableModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimteTableModel tm = new TimteTableModel();
                tm.EmpName = dt.Rows[i]["EmpName"].ToString();
                tm.EmpId = dt.Rows[i]["EmpId"].ToString();

                tm.Date = dt.Rows[i]["Date"].ToString();
                tm.Time = dt.Rows[i]["Time"].ToString();
                tm.RoomNo = dt.Rows[i]["roomno"].ToString();
                timetableList.Add(tm);
            }
            return View(timetableList);
        }

        

 public ActionResult ExportToCsvTimeTable()
        {
            var dt = dal.TimeTableList();
            List<TimteTableModel> timetableList = new List<TimteTableModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimteTableModel tm = new TimteTableModel();
                tm.EmpName = dt.Rows[i]["EmpName"].ToString();
                tm.EmpId = dt.Rows[i]["EmpId"].ToString();

                tm.Date = dt.Rows[i]["Date"].ToString();
                tm.Time = dt.Rows[i]["Time"].ToString();
                tm.RoomNo = dt.Rows[i]["roomno"].ToString();
                timetableList.Add(tm);
            }


            // Create a StringBuilder to hold the CSV data
            StringBuilder csvContent = new StringBuilder();

            // Add the header row
            csvContent.AppendLine("Name,EmpID,Room,Date,Time");

            // Add data rows
            foreach (var ds in timetableList)
            {
                csvContent.AppendLine($"{ds.EmpName},{ds.EmpId},{ds.RoomNo},{ds.Date},{ds.Time}");
            }

            // Create a byte array from the CSV data
            byte[] fileBytes = Encoding.UTF8.GetBytes(csvContent.ToString());

            // Return the CSV file as a file download
            return File(fileBytes, "text/csv", "DutyRoaster.csv");
        }


        public ActionResult ViewDateSheet()
        {
            var dt = dal.getDateSheet();
            List<DateSheetModel> dsList = new List<DateSheetModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateSheetModel dm = new DateSheetModel();
                dm.DateSheetID = Convert.ToInt32(dt.Rows[i]["DateSheetID"]);
                dm.Studentid = dt.Rows[i]["Studentid"].ToString();

                dm.ExamDate = Convert.ToDateTime(dt.Rows[i]["ExamDate"]);
                dm.Subject = dt.Rows[i]["Subject"].ToString();
                dm.ExTime = dt.Rows[i]["exTime"].ToString();
                dm.RoomNo = dt.Rows[i]["RooomNo"].ToString();
                dm.SeatNo = dt.Rows[i]["seatNo"].ToString();

                dsList.Add(dm);
            }
            return View(dsList);
        }



        
        public ActionResult ExportToCsv()
        {
            var dt = dal.getDateSheet();
            List<DateSheetModel> dsList = new List<DateSheetModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateSheetModel dm = new DateSheetModel();
                dm.DateSheetID = Convert.ToInt32(dt.Rows[i]["DateSheetID"]);
                dm.Studentid = dt.Rows[i]["Studentid"].ToString();

                dm.ExamDate = Convert.ToDateTime(dt.Rows[i]["ExamDate"]);
                dm.Subject = dt.Rows[i]["Subject"].ToString();
                dm.ExTime = dt.Rows[i]["exTime"].ToString();
                dm.RoomNo = dt.Rows[i]["RooomNo"].ToString();
                dm.SeatNo = dt.Rows[i]["seatNo"].ToString();

                dsList.Add(dm);
            }

             

            // Create a StringBuilder to hold the CSV data
            StringBuilder csvContent = new StringBuilder();

            // Add the header row
            csvContent.AppendLine("Id,StudentID,ExamDate,Subject,Time,RoomNo,SeatNo");

            // Add data rows
            foreach (var ds in dsList)
            {
                csvContent.AppendLine($"{ds.DateSheetID},{ds.Studentid},{ds.ExamDate},{ds.Subject},{ds.ExTime},{ds.RoomNo},{ds.SeatNo}");
            }

            // Create a byte array from the CSV data
            byte[] fileBytes = Encoding.UTF8.GetBytes(csvContent.ToString());

            // Return the CSV file as a file download
            return File(fileBytes, "text/csv", "DateSheet1.csv");
        }

        public ActionResult ViewSeatingPlan()
        {
            var dt = dal.getDateSheet();
            List<DateSheetModel> dsList = new List<DateSheetModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateSheetModel dm = new DateSheetModel();
                dm.DateSheetID = Convert.ToInt32(dt.Rows[i]["DateSheetID"]);
                dm.Studentid = dt.Rows[i]["Studentid"].ToString();

                dm.ExamDate = Convert.ToDateTime(dt.Rows[i]["ExamDate"]);
                dm.Subject = dt.Rows[i]["Subject"].ToString();
                dm.ExTime = dt.Rows[i]["exTime"].ToString();
                dm.RoomNo = dt.Rows[i]["RooomNo"].ToString();
                dm.SeatNo = dt.Rows[i]["seatNo"].ToString();

                dsList.Add(dm);
            }
            return View(dsList);
        }
        public ActionResult Logout()
        {
            ViewBag.message = "You are logot out successfully!";
            return View();
        }  

        }
}