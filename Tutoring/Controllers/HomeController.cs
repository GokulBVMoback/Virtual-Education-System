using BLL.Helpers;
using BLL.Models;
using BLL.Services;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Data.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Tutoring.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _db = new MyDbContext();
        Usermanager usermanager= new Usermanager();
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
            if(ModelState.IsValid)
            {
                var userData = usermanager.Login(model);
                if(userData != null) 
                {
                    Config.CurrentUser = userData.userid;
                    Config.User = userData;
                    if(userData.usertype == Convert.ToInt32(Constant.SuperAdmin.ToString()))
                    {
                        return RedirectToAction("Index", "SuperAdmin");
                    }
                    else if(userData.usertype == Convert.ToInt32(Constant.School.ToString()))
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
                    return RedirectToAction("Login", "Home" , new {@msg="Wrong Username and Password" });
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
    }
}