using BLL.Helpers;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutoring.Controllers
{
    public class SuperAdminController : Controller
    {
        public AdminManager adminManager=new AdminManager();
        // GET: SuperAdmin

        public ActionResult Index()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult GetAllSchool()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var schoolData = adminManager.GetSchool();
            ViewBag.data = schoolData;
            return View();
        }

        public ActionResult GetAllIndividualTeacher()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetIndividualTeachers();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllIndividualStudent()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetIndividualStudents();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllCourseBrach()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetCourseBranch();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllCourseTopic()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetCourseTopic();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllCourses()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetAllCourse();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllSubject()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetSubject();
            ViewBag.data = Data;
            return View();
        }

        public ActionResult GetAllUsers()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetUsers();
            ViewBag.data = Data;
            return View();
        }
    }
}