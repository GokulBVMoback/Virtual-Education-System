using BLL.Helpers;
using BLL.Models;
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

        
        public ActionResult TeacherViewForStudent()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            DateTime currentDate = DateTime.Now.Date;
            var classdata = _studentManager.TimetableForSchoolStudent(Config.User.fkschoolID, currentDate);
            List<teacherdata> ltd = new List<teacherdata>();
            foreach(var item in classdata)
            {
                var itemdata = ltd.FirstOrDefault(x => x.firstname == item.firstname && x.subjectname == item.subjectname);
                if (itemdata == null)
                {
                    teacherdata td = new teacherdata();
                    td.firstname = item.firstname;
                    td.subjectname = item.subjectname;
                    ltd.Add(td);
                }
            }
            
            ViewBag.data = ltd;
            return View();
        }

        //--------------------School Student Methods End Here ---------------------------

        //--------------------Individual Student Methods Start Here ---------------------------

        public class teacherdata
        {
            public string firstname { get; set; }
            public string subjectname { get; set; }
        }



        public ActionResult GetIndividualStudentDetails()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var studentData = _studentManager.GetIndividualStudentDetails((int)Config.User.userid);
            return View(studentData);
        }

        
        public ActionResult CouseMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = _studentManager.courseViews();
            ViewBag.data = classdata;

            var studentData = _studentManager.indSt(Config.User.userid);
            ViewBag.data1 = studentData;

            if(studentData.Count==0)
            {
                ViewBag.data2 = "0";
            }
            else
            {
                ViewBag.data2 = "1";
            }

            return View();
        }    

        
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
        }

        public ActionResult Profile1()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var profile = Usermanager.Profile();
            // ViewBag.data = profile;
            return View(profile);
        }


        public ActionResult EnrollNow(int id)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.id = id;
            var model = _db.tbl_course.FirstOrDefault(x => x.courseid == id);
            var item = _db.tbl_teacher_availability.Where(x => x.fkuserid ==model.fkuserid).ToList(); ;
            ViewBag.c = item;
            return View();
        }

        [HttpPost]
        public ActionResult EnrollNow(int id, int id1)
        {
            var model = _db.tbl_course.FirstOrDefault(x => x.courseid == id);

            tbl_avail_course ac = new tbl_avail_course();
            ac.fkuserid = Config.CurrentUser;
            ac.fkcourseid = model.courseid;
            ac.fkteacheravailid=id1;
            ac.payment = model.coursefee;
            ac.isconfirm = true;
            _db.tbl_avail_course.Add(ac);
            _db.SaveChanges();
           
          return RedirectToAction("Index", "Student");
           
        }

    }
}