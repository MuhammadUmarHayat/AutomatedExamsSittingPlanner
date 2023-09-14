using Exam_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Planner.Controllers
{
    public class FacultyAccountController : Controller
    {
        // GET: FacultyAccount
        DAL dal = new DAL();
        public ActionResult Signup()
        {
            
            return View();

           

        }
        [HttpPost]
        public ActionResult Signup(FacultyModel faculty)
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
                   
                    string type = faculty.Emp_type.ToString();

                    string add = faculty.Address.ToString();


                    Boolean result = dal.saveFaculty(empid, name, pw, designation, doa, status, type, add);
                    if (result)
                    {
                        ViewBag.Message = "You are registered  added successfully";
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
        public ActionResult Login()
        {
           
            return View();

        }
        [HttpPost]
        public ActionResult Login(FacultyModel fm)
        {
            string id = fm.EmpID.ToString();
            string password = fm.Password.ToString();
            // validate admin
            if (id.Equals("admin")&& password.Equals("admin"))
            {
                return RedirectToAction("Index", "AdminHome");
            }
            if (id.Equals("examDepartment") && password.Equals("examDepartment"))
            {
                return RedirectToAction("Index", "AdminHome");
            }
            bool result=  dal.isFaculty(id,  password);

            if (result)
            {
                ViewBag.Message = "You are registered  added successfully";
                Session["UserID"] = id;
              
              
                return RedirectToAction("Index","FacultyHome");
             

            }
            else
            {
                ViewBag.Message = "Please enter corract id and password";
            }

            return View();
           

        }
    }
}