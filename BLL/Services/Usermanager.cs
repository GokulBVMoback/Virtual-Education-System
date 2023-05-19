using BLL.Helpers;
using BLL.Models;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   
    public class Usermanager
    {
        MyDbContext _db = new MyDbContext();

        public tbl_users Login (LoginModel model)
        {
            var item = _db.tbl_users.FirstOrDefault(x => x.email == model.UserName && x.pass == model.Password);
            return item;
        }

        public bool ChangePassword(ChangePassword newPassword)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == Config.CurrentUser);
                if (item != null && item.pass==newPassword.OldPassword && newPassword.NewPassword==newPassword.ConfirmPassword)
                {   
                    item.pass = newPassword.NewPassword;
                    item.up_date=System.DateTime.Now;
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
      
        public tbl_users Profile()
        {
            var item = _db.tbl_users.FirstOrDefault(x => x.userid == Config.CurrentUser);
                return item;
        }

    }
}
