using BLL.Helpers;
using BLL.Services;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutoring.Controllers
{
    public class SchoolController : Controller
    {
        TeacherManager teachermanager = new TeacherManager();
        MyDbContext _db = new MyDbContext();
        // GET: School
        public ActionResult Index()
        {
            if(Config.CurrentUser==0)
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
            var teacherData = teachermanager.TeacherList(Config.User.fkschoolID);
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
                if(itemdata==true)
                {
                    return RedirectToAction("TeacherMaster", "School");
                }
                else
                {
                    return RedirectToAction("CreateTeacher", "School", new {@msg="Something went wrong" });
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
                string filename ="Teacher" + num + ".jpg";
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
    }
}