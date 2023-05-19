using BLL.Helpers;
using BLL.Services;
using DAL.MasterEntity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BLL.Models;

namespace Tutoring.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager teacherManager=new TeacherManager();
        Usermanager usermanager=new Usermanager();
        MyDbContext _db = new MyDbContext();

        // GET: Teacher
        public ActionResult Index()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult TeacherProfile()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var teacher = teacherManager.TeacherList(Config.User.userid);
            ViewBag.Data = teacher;
            return View();
        }
        //..................................................................................................................//
        /// <summary>
        /// teacher profile 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>

        //profile retreive
        [HttpGet]
        public ActionResult Profile()

        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Profile", "Teacher");
            }
            var teacherData = teacherManager.TeacherProfile(Config.CurrentUser);
            return View(teacherData);
        }

        //profile update
        public ActionResult UpdateTeacher()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_users.First(s=>s.userid==Config.CurrentUser);
            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(tbl_users model)
        {

            var itemdata = teacherManager.UpdateTeacher(model);
            if (itemdata == true)
            {
                return RedirectToAction("Profile", "Teacher");
            }
            else
            {
                return RedirectToAction("UpdateTeacher", "Teacher", new { @msg = "Something went wrong" });
            }

            return View();
        }

        //...........................................................................................................//
        /// <summary>
        /// crud for courses
        /// </summary>
        /// <returns></returns>
        
        //retreive
        public ActionResult Course()
        {
            if(Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var coursedata=teacherManager.CouserList();
            ViewBag.Course = coursedata;
            return View();
        }


        //create
        public ActionResult CreateCourse(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(tbl_course model)
        {
          
            
            var itemdata = teacherManager.CreateCourse(model);
            if (itemdata == true)
            {
                return RedirectToAction("Course", "Teacher");
            }
            else
            {
                return RedirectToAction("Course", "Teacher", new { @msg = "Something went wrong" });
            }

            return View();
        }

        //update
        public ActionResult UpdateCourse(int courseid)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_course.First(x => x.courseid == courseid);
            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateCourse(tbl_course model)
        {
            
            var itemdata = teacherManager.UpdateCourse(model);
            if (itemdata == true)
            {
                return RedirectToAction("Course", "Teacher");
            }
            else
            {
                return RedirectToAction("UpdateCourse", "Teacher", new { @msg = "Something went wrong" });
            }

            return View();
        }

        //delete
        public ActionResult DeleteCourse(long courseid)
        {
            var itemdata = teacherManager.DeleteCourse(courseid);

            return RedirectToAction("Course", "Teacher");


        }

        //.......................................................................................................//
        /// <summary>
        /// crud for Timetable
        /// </summary>
        /// <returns></returns>

        //retreive
        public ActionResult Timetable()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            DateTime currentDate = DateTime.Now.Date;
            var timetable = teacherManager.Timetable(Config.User.userid, currentDate);
            ViewBag.Timetable = timetable;
            return View();
        }

        //create
        public ActionResult CreateTimetable(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreatetimeTable(tbl_timetable model)
        {


            var itemdata = teacherManager.CreateTimetable(model);
            if (itemdata == true)
            {
                return RedirectToAction("Timetable", "Teacher");
            }
            else
            {
                return RedirectToAction("Timetable", "Teacher", new { @msg = "Something went wrong" });
            }

            return View();
        }

        //update
        public ActionResult UpdateTimetable(int timetableid)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_timetable.First(x => x.timetableid == timetableid);
            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateTimetable(tbl_timetable model)
        {

            var itemdata = teacherManager.UpdateTimetable(model);
            if (itemdata == true)
            {
                return RedirectToAction("Timetable", "Teacher");
            }
            else
            {
                return RedirectToAction("UpdateTimetable", "Teacher", new { @msg = "Something went wrong" });
            }

            return View();
        }

        //delete
        public ActionResult DeleteTimetable(long timetableid)
        {
            var itemdata = teacherManager.DeleteTimetable(timetableid);

            return RedirectToAction("Timetable", "Teacher");


        }


        //...................................................................................................................//
        /// <summary>
        /// reteive of student
        /// </summary>
        /// <returns></returns>
        
        //for school teacher
        public ActionResult Student()
        {        
            List<tbl_student> students = teacherManager.GetStudent(Config.User.fkschoolID);
            ViewBag.data=students;
            return View();
        }

        //for individual teacher
        public ActionResult courseStudent()
        {
            List<TeacherCouseView> courseStudent=teacherManager.GetCourseStudent(Config.User.fkschoolID);
            ViewBag.data=courseStudent;
            return View();
        }

        //......................................................................................................//
        /// <summary>
        /// change password
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>

        public ActionResult ChangePassword(string msg)
        {
            if(Config.CurrentUser == 0)
            {
                return RedirectToAction("Profile", "Teacher");
            }
            ViewBag.msg = msg;
            return View();

        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword user)
        {
            var item = usermanager.ChangePassword(user);
            if(item==true)
            {
                return RedirectToAction("Profile", "Teacher");
            }
            else
            {
                return RedirectToAction("ChangePassword", "Teacher", new { @msg = "Something went wrong" });
            }
        }

        //.....................................................................................................................................//
        /// <summary>
        /// retrieve subject details
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Subjects()
        {
            List<DAL.Entities.SubjectView> subjects = teacherManager.GetSubjects(Config.User.fkschoolID);
            ViewBag.data = subjects;
            return View();
        }
        
        //...................................................................................................................//


























        //public ActionResult Profile(long fkuserid)
        //{
        //    if (Config.CurrentUser == 0)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    var teacher = teacherManager.Profile(Config.CurrentUser);
        //    ViewBag.data = teacher;
        //    return View();
        //}

        //public ActionResult Course()
        //{
        //    if (Config.CurrentUser == 0)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    var coursedata = teacherManager.CouserList();
        //    ViewBag.Course = coursedata;
        //    return View();
        //}


        //public ActionResult Timetable()
        //{
        //    if (Config.CurrentUser == 0)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    DateTime currentDate = DateTime.Now.Date;
        //    List<Timetableview> timetable = teacherManager.Timetable(Config.User.userid, currentDate);

        //    ViewBag.Timetable = timetable;
        //    return View();
        //}
        //public ActionResult Timetable()
        //{
        //    if (Config.CurrentUser == 0)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    var timetabledata = teacherManager.TimetableList(Config.CurrentUser);
        //    ViewBag.Timetable = timetabledata;
        //    return View();
        //}

        ////////public ActionResult Student()
        ////////{
        ////////    if (Config.CurrentUser == 0 )
        ////////    {
        ////////        return RedirectToAction("Login", "Home");
        ////////    }
        ////////    var student = teacherManager.StudentList();
        ////////    ViewBag.data = student;
        ////////    return View();
        ////////}

    }
}