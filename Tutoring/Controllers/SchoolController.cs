using BLL.Helpers;
using BLL.Services;
using BLL.Servicess;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Tutoring.Models;

namespace Tutoring.Controllers
{
    public class SchoolController : Controller
    {
        TeacherManager teachermanager = new TeacherManager();
        SchoolManager schoolmanager = new SchoolManager();
        StudentManager studentmanager = new StudentManager();
        SubjectManager subjectmanager = new SubjectManager();
        TimetableManager timetablemanager = new TimetableManager();
        Change_Password change_password=new Change_Password();
        Usermanager Usermanager=new Usermanager();  
        MyDbContext _db = new MyDbContext();

        // GET: School
        public ActionResult Index()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult TeacherMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var teacherData = teachermanager.TeacherList(Config.CurrentUser);
            ViewBag.data = teacherData;
            return View();
        }
        public ActionResult CreateTeacher(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeacher(tbl_users model, HttpPostedFileBase uploadFile1)
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
                string filename = "Teacher" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = "0"; }
            model.userimage = s1;

            var itemdata = teachermanager.CreateTeacher(model);
            if (itemdata == true)
            {
                return RedirectToAction("TeacherMaster", "School");
            }
            else
            {
                return RedirectToAction("CreateTeacher", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }

        public ActionResult UpdateTeacher(int userid)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_users.First(x => x.userid == userid);
            ViewBag.cover = itemdata.userimage;
            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(tbl_users model, HttpPostedFileBase uploadFile1)
        {
            string s1;
            string s2;
            if (uploadFile1 != null)
            {
                string path = Server.MapPath("~/Content/UserImage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random rd = new Random();
                int num = rd.Next(100000, 200000);
                string filename = "Teacher" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = model.userimage; }
            model.userimage = s1;

            var itemdata = teachermanager.UpdateTeacher(model);
            if (itemdata == true)
            {
                return RedirectToAction("TeacherMaster", "School");
            }
            else
            {
                return RedirectToAction("UpdateTeacher", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }

        public ActionResult DeleteTeacher(long userid)
        {
            var itemdata = teachermanager.DeleteTeacher(userid);

            return RedirectToAction("TeacherMaster", "School");


        }



        public ActionResult ClassMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var classdata = schoolmanager.Classlist(Config.CurrentUser);
            ViewBag.data = classdata;
            return View();
        }


        public ActionResult CreateClass(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult CreateClass(tbl_class model)
        {
            string s1;


            var itemdata = schoolmanager.CreateClass(model);
            if (itemdata == true)
            {
                return RedirectToAction("ClassMaster", "School");
            }
            else
            {
                return RedirectToAction("ClassMaster", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }
        public ActionResult DeleteClass(long Classid)
        {
            var itemdata = schoolmanager.DeleteClass(Classid);

            return RedirectToAction("Classmaster", "School");


        }

        public ActionResult UpdateCLass(int classid)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_class.First(x => x.classid == classid);

            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateCLass(tbl_class model)
        {
            var itemdata = schoolmanager.UpdateClass(model);
            if (itemdata == true)
            {
                return RedirectToAction("Classmaster", "School");
            }
            else
            {
                return RedirectToAction("updateclass", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }

        public ActionResult StudentMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var teacherData = studentmanager.Studentlist(Config.CurrentUser);
            ViewBag.data = teacherData;
            return View();
        }
        public ActionResult CreateStudent(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            var Classdata = _db.tbl_class.Where(x => x.fkschoolid == Config.CurrentUser);
            ViewBag.c = Classdata;

            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student_Reg model, HttpPostedFileBase uploadFile1)
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
                string filename = "Student" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = "0"; }
            model.userimage = s1;

            tbl_users users = new tbl_users();
            users.state = model.state;
            users.email = model.email;
            users.isactive = model.isactive;
            users.address = model.address;
            users.city = model.city;
            users.country = model.country;
            users.pin = model.pin;
            users.cr_date = System.DateTime.Now;
            users.firstname = model.firstname;
            users.lastname = model.lastname;
            users.pass = model.pass;
            users.contact = model.contact;
            users.fkschoolID = Config.CurrentUser;
            users.usertype = Convert.ToInt32(Constant.Student.ToString());
            users.sex = model.sex;
            users.userimage = model.userimage;
            _db.tbl_users.Add(users);
            _db.SaveChanges();


            tbl_student users1 = new tbl_student();
            users1.state = model.state;
            users1.email = model.email;
            users1.fathername = model.fatherName;
            users1.mothername = model.motherName;
            users1.address = model.address;
            users1.city = model.city;
            users1.country = model.country;
            users1.pin = model.pin;
            users1.cr_date = System.DateTime.Now;
            users1.firstname = model.firstname;
            users1.lastname = model.lastname;
            users1.fkuserid = users.userid;
            users1.fkclassid= model.fkclassId;
            users1.contact = model.contact;
            users1.fkschoolid = Config.CurrentUser;
            
            users1.sex = model.sex;
            
            _db.tbl_student.Add(users1);
            _db.SaveChanges();


            return RedirectToAction("StudentMaster", "School");
            
            

            return View();
        }

        public ActionResult UpdateStudent(int userid)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var itemdata = _db.tbl_users.First(x => x.userid == userid);
            ViewBag.cover = itemdata.userimage;
            return View(itemdata);
        }

        [HttpPost]
        public ActionResult UpdateStudent(tbl_users model, HttpPostedFileBase uploadFile1)
        {
            string s1;
            string s2;
            if (uploadFile1 != null)
            {
                string path = Server.MapPath("~/Content/UserImage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random rd = new Random();
                int num = rd.Next(100000, 200000);
                string filename = "Student" + num + ".jpg";
                uploadFile1.SaveAs(path + filename);
                s1 = "Content/UserImage/" + filename;
            }
            else { s1 = model.userimage; }
            model.userimage = s1;

            var itemdata = studentmanager.UpdateStudent(model);
            if (itemdata == true)
            {
                return RedirectToAction("StudentMaster", "School");
            }
            else
            {
                return RedirectToAction("UpdateStudent", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }

        public ActionResult DeleteStudent(long userid)
        {
            var itemdata = studentmanager.DeleteStudent(userid);

            return RedirectToAction("StudentMaster", "School");


        }

        public ActionResult SubjectMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            var subjectdata = _db.ClassSubject.Where(x => x.fkschoolid == Config.CurrentUser);
            ViewBag.data = subjectdata;
            return View();
        }


        public ActionResult CreateSubject(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            var classitem = _db.tbl_class.Where(x => x.fkschoolid == Config.CurrentUser);
            ViewBag.classdata = classitem;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubject(tbl_subject model)
        {
            var itemdata = subjectmanager.CreateSubject(model);
            if (itemdata == true)
            {
                return RedirectToAction("SubjectMaster", "School");
            }
            else
            {
                return RedirectToAction("SubjectMaster", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }
        public ActionResult DeleteSubject(long subjectid)
        {
            var itemdata = subjectmanager.DeleteSubject(subjectid);

            return RedirectToAction("SubjectMaster", "School");


        }

        public ActionResult UpdateSubject(long subjectid, string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSubject(long subjectid, tbl_subject model)
        {
            var itemdata = subjectmanager.UpdateSubject(subjectid, model);
            if (itemdata == true)
            {
                return RedirectToAction("SubjectMaster", "School");
            }
            else
            {
                return RedirectToAction("SubjectMaster", "School", new { @msg = "Something went wrong" });
            }
        }

        public ActionResult TimetableMaster()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
           

            var timetable = timetablemanager.timetablelist(Config.CurrentUser);
            ViewBag.data = timetable;
            return View();
        }


        public ActionResult CreateTimetable(string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            var Teacherdata = _db.tbl_users.Where(x => x.fkschoolID == Config.CurrentUser && x.usertype == 3);
            ViewBag.t = Teacherdata;

            var Classdata = _db.tbl_class.Where(x => x.fkschoolid == Config.CurrentUser);
            ViewBag.c = Classdata;

            var subjectdata = _db.tbl_subject.Where(x => x.fkschoolid == Config.CurrentUser);
            ViewBag.s = subjectdata;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTimetable(tbl_timetable model)
        {
            var itemdata = timetablemanager.CreateTimetable(model);
            if (itemdata == true)
            {
                return RedirectToAction("TimetableMaster", "School");
            }
            else
            {
                return RedirectToAction("TimetableMaster", "School", new { @msg = "Something went wrong" });
            }

            return View();
        }
       

        public ActionResult UpdateTimetable(long timetableid, string msg)
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.msg = msg;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateTimetable(long timetableid, tbl_timetable model)
        {
            var itemdata = timetablemanager.Updatetimetable(timetableid, model);
            if (itemdata == true)
            {
                return RedirectToAction("TimetableMaster", "School");
            }
            else
            {
                return RedirectToAction("TimetableMaster", "School", new { @msg = "Something went wrong" });
            }
        }
        public ActionResult DeleteTimetable(long timetableid)
        {
            var itemdata = timetablemanager.DeleteTimetable(timetableid);

            return RedirectToAction("TimetableMaster", "School");


        }
        public ActionResult ChangePassword()
        {
            if (Config.CurrentUser == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(changepassword pass)
        {
            var itemdata = change_password.ChangePassword(pass);
            if (itemdata == true)
            {
                return RedirectToAction("Index", "School");
            }
            else
            {
                return RedirectToAction("ChangePassword", "School", new { @msg = "Something went wrong" });
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