using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BLL.Helpers
{
  public static  class Config
    {


        public static Int64 CurrentUser
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["userid"] == null)
                    return 0;
                else
                    return Convert.ToInt64(System.Web.HttpContext.Current.Session["userid"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["userid"] = value;
            }
        }

        public static tbl_users User
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["User"] == null)
                    return null;
                else
                    return (tbl_users)System.Web.HttpContext.Current.Session["User"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["User"] = value;
            }
        }

        public static tbl_users SchoolUser
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["SchoolUser"] == null)
                    return null;
                else
                    return (tbl_users)System.Web.HttpContext.Current.Session["SchoolUser"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["SchoolUser"] = value;
            }
        }

        //public static UsersProfile UsersProfile
        //{
        //    get
        //    {
        //        if (System.Web.HttpContext.Current.Session["UsersProfile"] == null)
        //            return null;
        //        else
        //            return (UsersProfile)System.Web.HttpContext.Current.Session["UsersProfile"];
        //    }
        //    set
        //    {
        //        System.Web.HttpContext.Current.Session["UsersProfile"] = value;
        //    }
        //}

        //public static string WebsiteURL
        //{
        //    get
        //    {
        //        return Convert.ToString(ConfigurationManager.AppSettings["WebsiteURL"]);
        //    }
        //}
    }
}
