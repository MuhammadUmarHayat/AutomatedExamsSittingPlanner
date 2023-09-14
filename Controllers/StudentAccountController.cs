using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Planner.Models;

namespace Exam_Planner.Controllers
{
    public class StudentAccountController : Controller
    {
        // GET: StudentAccount
       
        DAL dal = new DAL();
        public ActionResult Signup()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Signup(StudentModel sm)
        {
            try
            {
                if (ModelState.IsValid)
                {



                  //  string studentid, string name, string program, string rollnumber, string password, string gender, string status)

                    string studentid = sm.Studentid.ToString();
                    string name = sm.Name.ToString();
                    string program = sm.Program.ToString();
                    string rollnumber = sm.Rollnumber.ToString();
                    string password = sm.Password.ToString();
                    string gender =sm.Gender.ToString();
                    string status =sm.Status.ToString();
                  


                    Boolean result = dal.saveStudent(studentid, name,program,rollnumber,password,gender,status);
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
        public ActionResult Login(StudentModel sm)
        {
            string id = sm.Studentid.ToString();
            string password = sm.Password.ToString();
            bool result = dal.isStudent(id, password);
            if (result)
            {
                ViewBag.Message = "You are registered  added successfully";
                Session["UserID"] = id;
                return RedirectToAction("Index", "StudentHome");


            }
            else
            {
                ViewBag.Message = "Please enter corract id and password";
            }

            return View();


        }
    }
}