using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class DateSheetController : Controller
    {
        DAL dal = new DAL();
        // GET: DateSheet
        public ActionResult Index()
        {
            var dt = dal.getDateSheet();
            List<DateSheetModel> dsList = new List<DateSheetModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateSheetModel dm = new DateSheetModel();
                dm.DateSheetID = Convert.ToInt32(dt.Rows[i]["DateSheetID"]);
                dm.Studentid = dt.Rows[i]["Studentid"].ToString();
                
                dm.ExamDate =Convert.ToDateTime( dt.Rows[i]["ExamDate"]);
                dm.Subject = dt.Rows[i]["Subject"].ToString();
                dm.ExTime = dt.Rows[i]["exTime"].ToString();
                dm.RoomNo = dt.Rows[i]["RooomNo"].ToString();
                dm.SeatNo = dt.Rows[i]["seatNo"].ToString();

                dsList.Add(dm);
            }
            return View(dsList);
        }

        // GET: DateSheet/Details/5
        public ActionResult Details(int id)
        {
            var dt = dal.getDateSheetbyid(id);

            int i = 0;//first row
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

        // GET: DateSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DateSheet/Create
        [HttpPost]
        public ActionResult Create(DateSheetModel ds)
        {
            try
            {
                if (ModelState.IsValid)
                {





                    string stid = ds.Studentid.ToString();
                    string exDate = ds.ExamDate.ToString();
                    string subject =ds.Subject.ToString() ;
                    string exTime = ds.ExTime.ToString();
                    string room = ds.RoomNo.ToString();
                    string sno = ds.SeatNo.ToString();



                    Boolean result = dal.saveDateSheet(stid, exDate, subject, exTime, room,sno);
                    if (result)
                    {
                        ViewBag.Message = "Date sheet is added successfully";
                        return RedirectToAction("index");
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

        // GET: DateSheet/Edit/5
        public ActionResult Edit(int id)
        {
            var dt = dal.getDateSheetbyid(id);

            int i = 0;//first row
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

        // POST: DateSheet/Edit/5
        [HttpPost]
        public ActionResult Edit(DateSheetModel dm)
        {
            try
            {
                string id = dm.DateSheetID.ToString();
                string sid = dm.Studentid.ToString();

                string ed = dm.ExamDate.ToString();
                string et = dm.ExTime.ToString();
                string sb = dm.Subject.ToString();
                string rm = dm.RoomNo.ToString();
                string sno = dm.SeatNo.ToString();




                Boolean result = dal.updateDateSheet(id, sid, ed, sb, et, rm,sno);
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

        // GET: DateSheet/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                string did = id.ToString();


                Boolean result = dal.deleteDateSheet(did);
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

        // POST: DateSheet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
