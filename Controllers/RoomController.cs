using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Planner.Models;

namespace Exam_Planner.Controllers
{
    public class RoomController : Controller
    {
      
        DAL dal = new DAL();

        // GET: Room
        public ActionResult Index()
        {
            
            var dt = dal.RoomsList();
            List<RoomModel> roomList = new List<RoomModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RoomModel room = new RoomModel();
                room.RoomNo = Convert.ToInt32(dt.Rows[i]["RoomNo"]);
               room.Floor = dt.Rows[i]["Floor"].ToString();
              room.Capacity = Convert.ToInt32(dt.Rows[i]["Capacity"]);

                roomList.Add(room);
            }
            return View(roomList);
        }
        //GET: Add Student
        public ActionResult AddRoom()
        {
            return View();
        }
        // POST: Add Student    
        [HttpPost]
        public ActionResult AddRoom(RoomModel rm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    

                    string RoomNo = rm.RoomNo.ToString();
                    string Floor = rm.Floor.ToString();
                    string Capacity = rm.Capacity.ToString();

                    Boolean result = dal.saveRoom(RoomNo,Floor,Capacity);
                    if (result)
                    {
                        ViewBag.Message = "Room details added successfully";
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
            var dt = dal.getRoom(id);

            int i = 0;//first row


            RoomModel room = new RoomModel();
            room.RoomNo = Convert.ToInt32(dt.Rows[i]["RoomNo"]);
            room.Floor = dt.Rows[i]["Floor"].ToString();
            room.Capacity = Convert.ToInt32(dt.Rows[i]["Capacity"]);


           

            return View(room);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = dal.getRoom(id);

            int i = 0;//first row
           
            RoomModel room = new RoomModel();
            room.RoomNo = Convert.ToInt32(dt.Rows[i]["RoomNo"]);
            room.Floor = dt.Rows[i]["Floor"].ToString();
            room.Capacity = Convert.ToInt32(dt.Rows[i]["Capacity"]);



            return View(room);

        }
        [HttpPost]
        public ActionResult Edit(RoomModel room)
        {
            try
            {

                string RoomNo = room.RoomNo.ToString();
                string floor = room.Floor.ToString();
                string capacity= room.Capacity.ToString();


                Boolean result = dal.updateRoom(RoomNo, floor, capacity);
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

                string roomNo = id.ToString();


                Boolean result = dal.deleteRoom(roomNo);
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