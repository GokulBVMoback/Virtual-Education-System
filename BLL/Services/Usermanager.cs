using BLL.Models;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
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
    }
}
