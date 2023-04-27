using BLL.Helpers;
using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutoring.Controllers
{
    public class SuperAdminController : Controller
    {
        public AdminManager adminManager=new AdminManager();
        public Usermanager usermanager=new Usermanager();
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

        public ActionResult GetAllCourseBranch()
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

        public ActionResult GetCourses(long CourseID)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var Data = adminManager.GetCourse(CourseID);
            //ViewBag.data = Data;
            return View(Data);
        }

        public ActionResult CreateSchool(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSchool(tbl_users model, HttpPostedFileBase uploadFile1)
        {
            string s1;

            if (uploadFile1 != null)
            {
                string path = Server.MapPath("~/Content/UserImage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random rd = new Random();
                int num = rd.Next(100000, 200000);
                string filename = "School" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = "0"; }
            model.userimage = s1;
            var itemdata = adminManager.CreateUser(model);
            if (itemdata == true)
            {
                return RedirectToAction("CreateSchool2", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateSchool", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult CreateSchool2(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSchool2(tbl_school School)
        {
            var itemdata = adminManager.CreateSchool(School.schoolname, School.curriculum, Config.SchoolUser);
            if (itemdata == true)
            {
                return RedirectToAction("GetAllSchool", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateSchool", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult CreateCourseBranch(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseBranch(tbl_course_branch Branch)
        {
            var itemdata = adminManager.CreateBranch(Branch);
            if (itemdata == true)
            {
                return RedirectToAction("GetAllCourseBranch", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateCourseBranch", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult CreateCourseTopic(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseTopic(tbl_course_topic Topic)
        {
            var itemdata = adminManager.CreateTopic(Topic);
            if (itemdata == true)
            {
                return RedirectToAction("GetAllCourseTopic", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateCourseTopic", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult UpdateSchool(long userid, string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View(new tbl_users());
        }

        [HttpPost]
        public ActionResult UpdateSchool(long userid,tbl_users model, HttpPostedFileBase uploadFile1)
        {
            string s1;

            if (uploadFile1 != null)
            {
                string path = Server.MapPath("~/Content/UserImage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random rd = new Random();
                int num = rd.Next(100000, 200000);
                string filename = "School" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = "0"; }
            model.userimage = s1;
            var itemdata = adminManager.UpdateUser(model);
            if (itemdata == true)
            {
                return RedirectToAction("UpdateSchool2", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("UpdateSchool", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult UpdateSchool2(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSchool2(tbl_school School)
        {
            var itemdata = adminManager.UpdateSchool(School.schoolname, School.curriculum, Config.SchoolUser);
            if (itemdata == true)
            {
                return RedirectToAction("GetAllSchool", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("UpdateSchool2", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult UpdateCourseBranch(long coursebranchid, string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCourseBranch(long coursebranchid, tbl_course_branch Branch)
        {
            var itemdata = adminManager.UpdateBranch(coursebranchid, Branch);
            if (itemdata == true)
            {
                return RedirectToAction("GetAllCourseBranch", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateCourseBranch", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult UpdateCourseTopic(long coursetopicid, string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCourseTopic(long coursetopicid, tbl_course_topic Topic)
        {
            var itemdata = adminManager.UpdateTopic(coursetopicid, Topic);

            if (itemdata == true)
            {
                return RedirectToAction("GetAllCourseTopic", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("CreateCourseTopic", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult ChangePassword(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(tbl_users User)
        {
            var itemdata = usermanager.ChangePassword(User.pass);
            if (itemdata == true)
            {
                return RedirectToAction("Index", "SuperAdmin");
            }
            else
            {
                return RedirectToAction("ChangePassword", "SuperAdmin", new { @msg = "Something went wrong" });
            }
        }
    }
}