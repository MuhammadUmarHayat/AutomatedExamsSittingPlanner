using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exam_Planner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //main 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //sigup for employees
            routes.MapRoute(
               name: "Faculty-Signup",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "FacultyAccountController", action = "Signup", id = UrlParameter.Optional }
           );
            
            routes.MapRoute(
              name: "Faculty-Login",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "FacultyAccountController", action = "Login", id = UrlParameter.Optional }
          );


            //sigup for student
            routes.MapRoute(
               name: "Student-Signup",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "StudentAccountController", action = "Signup", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Student-Login",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "StudentAccountController", action = "Login", id = UrlParameter.Optional }
          );

            //Route for Student information 
         

            routes.MapRoute(
                name: "Studentlist",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Create",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Student", action = "AddStudent", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Edit",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Student", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Delete",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Student", action = "Delete", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "StudentDetails",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Student", action = "Details", id = UrlParameter.Optional }
          );
           //Route for room information
            routes.MapRoute(
                         name: "RoomList",
                         url: "{controller}/{action}/{id}",
                         defaults: new { controller = "Room", action = "Index", id = UrlParameter.Optional }
                     );

            routes.MapRoute(
                                    name: "CreateRoom",
                                     url: "{Room}/{AddRoom}/{id}",
                                     defaults: new { controller = "Room", action = "AddRoom", id = UrlParameter.Optional }
                                 );

            routes.MapRoute(
              name: "Edit-Room",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Room", action = "Edit", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Delete-Room",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Room", action = "Delete", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Room-Details",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Room", action = "Details", id = UrlParameter.Optional }
          );


            //Routes for faculty
            routes.MapRoute(
                         name: "FacultyList",
                         url: "{controller}/{action}/{id}",
                         defaults: new { controller = "Faculty", action = "Index", id = UrlParameter.Optional }
                     );

            routes.MapRoute(
                                    name: "CreateFaculty",
                                     url: "{Room}/{AddRoom}/{id}",
                                     defaults: new { controller = "Faculty", action = "AddFaculty", id = UrlParameter.Optional }
                                 );

            routes.MapRoute(
              name: "Edit-Faculty",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Faculty", action = "Edit", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "Delete-Faculty",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Faculty", action = "Delete", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Faculty-Details",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Faculty", action = "Details", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                                    name: "TimeTableList",
                                    url: "{controller}/{action}/{id}",
                                    defaults: new { controller = "TimteTable", action = "Index", id = UrlParameter.Optional }
                                );

            routes.MapRoute(
                                    name: "CreateTimeTable",
                                     url: "{Room}/{AddRoom}/{id}",
                                     defaults: new { controller = "TimteTable", action = "AddTimeTable", id = UrlParameter.Optional }
                                 );
            //route for admin logout
            routes.MapRoute(
                                             name: "AdminLogout",
                                              url: "{Room}/{AddRoom}/{id}",
                                              defaults: new { controller = "FacultyHome", action = "Logout", id = UrlParameter.Optional }
                                          );
            //route for employee logout 
            routes.MapRoute(
                                               name: "EmployeeLogout",
                                                url: "{Room}/{AddRoom}/{id}",
                                                defaults: new { controller = "FacultyHome", action = "Logout", id = UrlParameter.Optional }
                                            );
            //route for student logout
            routes.MapRoute(
                                             name: "StudentLogout",
                                              url: "{Room}/{AddRoom}/{id}",
                                              defaults: new { controller = "FacultyHome", action = "Logout", id = UrlParameter.Optional }
                                          );
        }
    }
}
