using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class FacultyController : Controller
    {
       
        DAL dal = new DAL();

        // GET: Faculty
        public ActionResult Index()
        {
           
            var dt = dal.FacultyList();
            List<FacultyModel> facultyList = new List<FacultyModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FacultyModel faculty = new FacultyModel();
                faculty.EmpID = dt.Rows[i]["EmpID"].ToString();
                faculty.Full_name = dt.Rows[i]["full_name"].ToString();
               
                faculty.Designation = dt.Rows[i]["Designation"].ToString();
                faculty.Date_Of_Appointment = dt.Rows[i]["Date_Of_Appointment"].ToString();
                faculty.Status = dt.Rows[i]["Status"].ToString();
                faculty.Emp_type = dt.Rows[i]["Emp_type"].ToString();
                faculty.Address = dt.Rows[i]["Address"].ToString();



                facultyList.Add(faculty);
            }
            return View(facultyList);
        }
        //GET: Add Faculty
        public ActionResult AddFaculty()
        {
            return View();
        }
        // POST: Add Student    
        [HttpPost]
        public ActionResult AddFaculty(FacultyModel faculty)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    
                    


                    string empid = faculty.EmpID.ToString();
                    string name = faculty.Full_name.ToString();
                    string pw = faculty.Password.ToString();
                    string designation = faculty.Designation.ToString();
                    string doa = faculty.Date_Of_Appointment.ToString();
                    string status = faculty.Status.ToString();
                   string type= faculty.Emp_type.ToString();
                    string add=faculty.Address.ToString();


                    Boolean result = dal.saveFaculty(empid,name,pw,designation,doa,status,type,add);
                    if (result)
                    {
                        ViewBag.Message = "Faculty  details added successfully";
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
            var dt = dal.getFaculty(id);

            int i = 0;//first row
            FacultyModel faculty = new FacultyModel();
            faculty.EmpID = dt.Rows[i]["EmpID"].ToString();
            faculty.Full_name = dt.Rows[i]["full_name"].ToString();
           
            faculty.Designation = dt.Rows[i]["Designation"].ToString();
            faculty.Date_Of_Appointment = dt.Rows[i]["Date_Of_Appointment"].ToString();
            faculty.Status = dt.Rows[i]["Status"].ToString();
            faculty.Emp_type = dt.Rows[i]["Emp_type"].ToString();
            faculty.Address = dt.Rows[i]["Address"].ToString();

            return View(faculty);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = dal.getFaculty(id);

            int i = 0;//first row
            FacultyModel faculty = new FacultyModel();
            faculty.EmpID = dt.Rows[i]["EmpID"].ToString();
            faculty.Full_name = dt.Rows[i]["full_name"].ToString();

            faculty.Designation = dt.Rows[i]["Designation"].ToString();
            faculty.Date_Of_Appointment = dt.Rows[i]["Date_Of_Appointment"].ToString();
            faculty.Status = dt.Rows[i]["Status"].ToString();
            faculty.Emp_type = dt.Rows[i]["Emp_type"].ToString();
            faculty.Address = dt.Rows[i]["Address"].ToString();

            return View(faculty);

        }
        [HttpPost]
        public ActionResult Edit(FacultyModel faculty)
        {
            try
            {
              
                string EmpID = faculty.EmpID.ToString();
                string full_name = faculty.Full_name.ToString();
                string designation = faculty.Designation.ToString();
                string date_of_appointment = faculty.Date_Of_Appointment.ToString();
                string address = faculty.Address.ToString();

                Boolean result = dal.updateFaculty( EmpID, full_name, designation, date_of_appointment, address);
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


                Boolean result = dal.deleteFaculty(fid);// dal.deleteStudent(studentid);
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
