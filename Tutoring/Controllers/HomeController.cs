using BLL.Helpers;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.MasterEntity;
using LinqToExcel.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Tutoring.Models;

namespace Tutoring.Controllers
{
    //public class MyViewModel
    //{
    //    public MyEnum SelectedEnumValue { get; set; }
    //}

    //public enum MyEnum
    //{
    //    Value1,
    //    Value2,
    //    Value3
    //}

    public enum UserType
    {
        Select_UserType,
        SuperAdmin,
        School,
        Teacher,
        Student
    }
    public class HomeController : Controller
    {
        MyDbContext _db = new MyDbContext();
        Usermanager usermanager = new Usermanager();
        // GET: Home
        public ActionResult Index()
        {
            var item = _db.tbl_users.ToList();

            ViewBag.data = item;

            return View();
        }


        #region Login

        public ActionResult Login(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userData = usermanager.Login(model);
                if (userData != null)
                {
                    Config.CurrentUser = userData.userid;
                    Config.User = userData;
                    if (userData.usertype == Convert.ToInt32(Constant.SuperAdmin.ToString()))
                    {
                        return RedirectToAction("Index", "SuperAdmin");
                    }
                    else if (userData.usertype == Convert.ToInt32(Constant.School.ToString()))
                    {
                        return RedirectToAction("Index", "School");
                    }
                    else if (userData.usertype == Convert.ToInt32(Constant.Teacher.ToString()))
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                    else if (userData.usertype == Convert.ToInt32(Constant.Student.ToString()))
                    {
                        return RedirectToAction("Index", "Student");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { @msg = "Wrong Username and Password" });
                }
            }
            else
            {
                return RedirectToAction("Login", "Home", new { @msg = "Something Went Wrong" });
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Config.CurrentUser = 0;
            Config.User = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Registration

        //School Registration
        [HttpGet]
        public ActionResult RegisterSchool(bool Issuccess = false)
        {

            ViewBag.issuccess = Issuccess;
            ViewBag.UserType = EnumHelper.GetSelectList(typeof(UserType));
            return View();



        }

        //{
        //    var model = new MyViewModel();
        //    model.SelectedEnumValue = MyEnum.Value2; // Set default selected value
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult RegisterSchool(School_Reg model /*MyViewModel model*/)
        {

            if (ModelState.IsValid)
            {

                tbl_school school = new tbl_school();

                school.schoolname = model.schoolname;
                school.contact = model.contact;
                school.address = model.address;
                school.city = model.city;
                school.state = model.state;
                school.country = model.country;
                school.pin = model.pin;
                school.curriculum = model.curriculum;
                school.fkuserid = model.fkuserid;
                school.schoolname = model.schoolname;


                SchoolManager schoolManager = new SchoolManager();
                long school_id = schoolManager.CreateSchool(school);

                tbl_users users = new tbl_users();
                users.firstname = model.firstname;
                users.lastname = model.lastname;
                users.email = model.email;
                users.address = model.address;
                users.city = model.city;
                users.state = model.state;
                users.country = model.country;
                users.pin = model.pin;
                users.pass = model.pass;
                users.usertype = model.usertype;
                users.isactive = model.isactive;
                users.sex = model.sex;
                users.contact = model.contact;
                users.fkschoolID = school_id;

                Usermanager userManager = new Usermanager();
                userManager.CreateUser(users);






            }


            return RedirectToAction("RegisterSchool", new { Issuccess = true });



        }


        //Teacher Registration

        [HttpGet]
        public ActionResult RegisterTeacher(bool Issuccess = false)
        {
            ViewBag.issuccess = Issuccess;
            ViewBag.UserType = EnumHelper.GetSelectList(typeof(UserType));
            return View();



        }

        [HttpPost]
        public ActionResult RegisterTeacher(tbl_users model)
        {
            if (ModelState.IsValid)
            {



                tbl_users users = new tbl_users();
                users.firstname = model.firstname;
                users.lastname = model.lastname;
                users.email = model.email;
                users.address = model.address;
                users.city = model.city;
                users.state = model.state;
                users.country = model.country;
                users.pin = model.pin;
                users.pass = model.pass;
                users.usertype = model.usertype;
                users.sex = model.sex;
                users.contact = model.contact;
                users.isactive = users.isactive;

                //TeacherManager teacherManager = new TeacherManager();

                Usermanager userManager = new Usermanager();
                userManager.CreateUser(users);
                //bool user_type = userManager.CreateUser(users);




            }


            return RedirectToAction("RegisterTeacher", new { Issuccess = true });

            //  return View();


        }



        //Student Registration
        [HttpGet]
        public ActionResult RegisterStudent(bool Issuccess = false)
        {

            ViewBag.issuccess = Issuccess;
            ViewBag.UserType = EnumHelper.GetSelectList(typeof(UserType));
            return View();



        }

        //{
        //    var model = new MyViewModel();
        //    model.SelectedEnumValue = MyEnum.Value2; // Set default selected value
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult RegisterStudent(Student_Reg model /*MyViewModel model*/)
        {

            if (ModelState.IsValid)
            {

                tbl_student student = new tbl_student();

                student.contact = model.contact;
                student.address = model.address;
                student.city = model.city;
                student.state = model.state;
                student.country = model.country;
                student.pin = model.pin;
                student.email = model.email;
                student.lastname = model.lastname;
                student.firstname = model.firstname;
                student.motherName = model.motherName;
                student.fatherName = model.fatherName;
                student.sex = model.sex;
                student.fkclassid = model.fkclassId;
                student.fkschoolid = model.fkschoolID;


                StudentManager studentManager = new StudentManager();
                long studentid = studentManager.Createstudent(student);

                tbl_users users = new tbl_users();
                users.firstname = model.firstname;
                users.lastname = model.lastname;
                users.email = model.email;
                users.address = model.address;
                users.city = model.city;
                users.state = model.state;
                users.country = model.country;
                users.pin = model.pin;
                users.pass = model.pass;
                users.usertype = model.usertype;
                users.isactive = model.isactive;
                users.sex = model.sex;
                users.contact = model.contact;
                users.fkschoolID = studentid;

                Usermanager userManager = new Usermanager();
                userManager.CreateUser(users);






            }


            return RedirectToAction("RegisterStudent", new { Issuccess = true });



        }
        #endregion

    }
}
