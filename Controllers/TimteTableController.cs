using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class TimteTableController : Controller
    {
        DAL dal = new DAL();
        // GET: TimteTable
        public ActionResult Index()
        {
            
            var dt = dal.TimeTableList();
            List<TimteTableModel> timetableList = new List<TimteTableModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimteTableModel tm = new TimteTableModel();
                tm.ID = dt.Rows[i]["id"].ToString();
                tm.EmpName = dt.Rows[i]["EmpName"].ToString();
                tm.EmpId = dt.Rows[i]["EmpId"].ToString();

                tm.Date = dt.Rows[i]["Date"].ToString();
                tm.Time = dt.Rows[i]["Time"].ToString();
                tm.RoomNo = dt.Rows[i]["Roomno"].ToString();
                tm.Status = dt.Rows[i]["Status"].ToString();




                timetableList.Add(tm);
            }
            return View(timetableList);
        }
        //GET: Add Student
        public ActionResult AddTimeTable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTimeTable(TimteTableModel tm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    string empName = tm.EmpName.ToString();
                    string empId = tm.EmpId.ToString();
                    string date = tm.Date.ToString();
                    string time = tm.Time.ToString();
                    string roomno = tm.RoomNo.ToString();
                    string status = "active";
                    //saveTimeTable(string empName, string empId, string roomno, string date, string time, string status)
                    Boolean result = dal.saveTimeTable(empName, empId, roomno, date, time,  status);
                    if (result)
                    {
                        ViewBag.Message = "Details added successfully";
                    }

                }
                else
                {
                    ViewBag.Message = "Please enter corract values";
                    return View();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var dt = dal.getTimeTable(id);

            int i = 0;//first row
            TimteTableModel tm = new TimteTableModel();

            tm.ID = dt.Rows[i]["id"].ToString();
            tm.EmpName = dt.Rows[i]["empName"].ToString();

            tm.EmpId = dt.Rows[i]["empid"].ToString();
            tm.RoomNo = dt.Rows[i]["roomno"].ToString();
            tm.Date= dt.Rows[i]["date"].ToString();
            tm.Time = dt.Rows[i]["time"].ToString();
            tm.Status = dt.Rows[i]["status"].ToString();

            return View(tm);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = dal.getTimeTable(id);

            int i = 0;//first row
            TimteTableModel tm = new TimteTableModel();

            tm.ID = dt.Rows[i]["id"].ToString();
            tm.EmpName = dt.Rows[i]["empName"].ToString();

            tm.EmpId = dt.Rows[i]["empid"].ToString();
            tm.RoomNo = dt.Rows[i]["roomno"].ToString();
            tm.Date = dt.Rows[i]["date"].ToString();
            tm.Time = dt.Rows[i]["time"].ToString();
            tm.Status = dt.Rows[i]["status"].ToString();

            return View(tm);

        }
        [HttpPost]
        public ActionResult Edit(TimteTableModel tm)
        {
            try
            {

                string id = tm.ID.ToString();
                string empname = tm.EmpName.ToString();
                string eid = tm.EmpId.ToString();
                string rm = tm.RoomNo.ToString();
                string d = tm.Date.ToString();
                string t = tm.Time.ToString();
                string s = tm.Status.ToString();

                Boolean result = dal.updateTimeTable(id, empname, eid, rm, d, t, s);
                if (result)
                {
                    return RedirectToAction("index");
                }



            }
            catch
            {
                return View();
            }

            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {

                string fid = id.ToString();


                Boolean result = dal.deleteTimeTable(id);
                if (result)
                {
                    return RedirectToAction("index");
                }



            }
            catch
            {
                return View();
            }

            return RedirectToAction("index");
        }


    }
}
