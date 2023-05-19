using BLL.Helpers;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BLL.Services
{
    public class Change_Password
    {
        MyDbContext _db = new MyDbContext();
        public bool ChangePassword(changepassword newpassword)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == Config.CurrentUser);
                if (item != null && item.pass == newpassword.OldPassword)
                {
                    item.pass = newpassword.NewPassword;
                    item.up_date = DateTime.Now;
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
    }
}
