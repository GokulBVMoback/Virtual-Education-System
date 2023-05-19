using BLL.Helpers;
using BLL.Services;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutoring.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        MyDbContext _db = new MyDbContext();
        StudentManager _studentManager = new StudentManager();
        Usermanager Usermanager = new Usermanager();
        public ActionResult Index()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        //--------------------School Student Methods Start Here ---------------------------
        [HttpGet]
        public ActionResult profile()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var studentData = _studentManager.GetSchoolStudentDetails((int)Config.User.userid);
            //ViewBag.data = teacherData;
            return View(studentData);
        }

        [HttpGet]
        public ActionResult TimetableForSchoolStudent()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            DateTime currentDate = DateTime.Now.Date;
            var classdata = _studentManager.TimetableForSchoolStudent(Config.User.fkschoolID, currentDate);
            ViewBag.data = classdata;
            return View();
        }

        [HttpGet]
        public ActionResult SubjectView()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = _studentManager.SubjectViews(Config.User.fkschoolID);
            ViewBag.data = classdata;
            return View();
        }

        [HttpGet]
        public ActionResult TeacherViewForStudent()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = _studentManager.TeacherViewForStudent();
            ViewBag.data = classdata;
            return View();
        }

        //--------------------School Student Methods End Here ---------------------------

        //--------------------Individual Student Methods Start Here ---------------------------


        [HttpGet]

        public ActionResult GetIndividualStudentDetails()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var studentData = _studentManager.GetIndividualStudentDetails((int)Config.User.userid);
            return View(studentData);
        }

        [HttpGet]
        public ActionResult CouseMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = _studentManager.courseViews();
            ViewBag.data = classdata;
            return View();
        }    

        [HttpGet]
        public ActionResult TimetableForIndividualStudent()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            DateTime currentDate = DateTime.Now.Date;
            var classdata = _studentManager.TimetableForIndividualStudent(Config.User.fkschoolID,currentDate);
            ViewBag.data = classdata;
            return View();
        }

        [HttpGet]
        public ActionResult TeacherViewForIndividualStudents()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = _studentManager.TeacherViewForIndividualStudents();
            ViewBag.data = classdata;
            return View();
        }


        [HttpGet]
        public ActionResult PurchaseCouse()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var studentData = _studentManager.indSt(Config.User.userid);
            ViewBag.data = studentData;
            return View();
        }

        //--------------------Individual Student Methods End Here ---------------------------
        public ActionResult ChangePassword()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword user)
        {
            var itemdata = _studentManager.ChangePassword(user);
            if (itemdata == true)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return RedirectToAction("ChangePassword", "Student", new { @msg = "Something went wrong" });
            }
            return View();
        }

        public ActionResult Profile()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var profile = Usermanager.Profile();
            // ViewBag.data = profile;
            return View(profile);
        }

    }
}