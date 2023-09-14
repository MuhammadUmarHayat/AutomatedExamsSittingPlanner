using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class StudentHomeController : Controller
    {
        DAL dal = new DAL();
        // GET: StudentHome
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
        //ViewDateSheet
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

        //ViewRollnoSlip
        public ActionResult ViewRollnoSlip()
        {
            string studentid = "";
            if (Session["UserID"] != null)
            {
                studentid = Session["UserID"].ToString();
            }
            else
            {
                return Redirect("Index");
            }

            var dt = dal.getStudentDateSheet(studentid);


           int i=0;
            if (dt.Rows.Count > 0)

            {
                DateSheetModel dm = new DateSheetModel();
                dm.DateSheetID = Convert.ToInt32(dt.Rows[i]["DateSheetID"]);
                dm.Studentid = dt.Rows[i]["Studentid"].ToString();

                dm.ExamDate = Convert.ToDateTime(dt.Rows[i]["ExamDate"]);
                dm.Subject = dt.Rows[i]["Subject"].ToString();
                dm.ExTime = dt.Rows[i]["exTime"].ToString();
                dm.RoomNo = dt.Rows[i]["RooomNo"].ToString();
                dm.SeatNo = dt.Rows[i]["seatNo"].ToString();



                return View(dm);
            }
            return View();
        }
        //ViewSiting
        public ActionResult ViewSiting()
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
    }
}