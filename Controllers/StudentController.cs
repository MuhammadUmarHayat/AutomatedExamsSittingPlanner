using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam_Planner.Models;

namespace Exam_Planner.Controllers
{
    public class StudentController : Controller
    {
        DAL dal = new DAL();
       
        // GET: Student
        public ActionResult Index()
        {
            // list =dal.studentList();
            var dt = dal.studentList();
            List<StudentModel> studentList = new List<StudentModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentModel student = new StudentModel();
                student.Studentid = dt.Rows[i]["Studentid"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Program = dt.Rows[i]["Program"].ToString();
                student.Rollnumber = dt.Rows[i]["Rollnumber"].ToString();
                studentList.Add(student);
            }
            return View(studentList);
        }
        //GET: Add Student
        public ActionResult AddStudent()
        {
            return View();
        }
        // POST: Add Student    
        [HttpPost]
        public ActionResult AddStudent(StudentModel std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string studentid = std.Studentid.ToString();
                    string name = std.Name.ToString();
                    string program = std.Program.ToString();
                    string rollnumber = std.Rollnumber.ToString();
                    string password = std.Password.ToString();
                    string gender = std.Gender.ToString();
                    string status = "active";
                    Boolean result = dal.saveStudent(studentid, name, program, rollnumber, password, gender, status);
                    if (result)
                    {
                        ViewBag.Message = "Student details added successfully";
                    }

                }
                else {
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
            var dt = dal.getStudent(id);

            int i = 0;//first row
            StudentModel student = new StudentModel();
            student.Studentid = dt.Rows[i]["Studentid"].ToString();
            student.Name = dt.Rows[i]["Name"].ToString();
            student.Program = dt.Rows[i]["Program"].ToString();
            student.Rollnumber = dt.Rows[i]["Rollnumber"].ToString();
            student.Gender = dt.Rows[i]["Gender"].ToString();

            return View(student);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = dal.getStudent(id);
            
            int i = 0;//first row
                StudentModel student = new StudentModel();
            student.Studentid = dt.Rows[i]["Studentid"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Program = dt.Rows[i]["Program"].ToString();
                student.Rollnumber = dt.Rows[i]["Rollnumber"].ToString();
             
           
            return View(student);
         
        }
        [HttpPost]
        public ActionResult Edit(StudentModel std)
        {
            try
            {
                
                    string studentid = std.Studentid.ToString();
                    string name = std.Name.ToString();
                    string program = std.Program.ToString();
                    string rollnumber = std.Rollnumber.ToString();
                   
                    Boolean result = dal.updateStudent(studentid, name, program, rollnumber);
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

                string studentid = id.ToString();
               

                Boolean result = dal.deleteStudent(studentid);
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