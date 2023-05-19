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

        public int? CreateUser(tbl_users model)
        {
            try
            {
                tbl_users user = new tbl_users();
                user.firstname = model.firstname;
                user.lastname = model.lastname;
                user.contact = model.contact;
                user.address = model.address;
                user.city = model.city;
                user.state = model.state;
                user.country = model.country;
                user.pin = model.pin;
                user.fkschoolID = model.fkschoolID;
                user.isactive = true;
                user.cr_date = DateTime.Now;

                user.sex = model.sex;
                user.usertype = model.usertype;
                user.email = model.email;
                user.pass = model.pass;


                _db.tbl_users.Add(user);
                _db.SaveChanges();
                var id = user.usertype;
                return id;
            }
            catch
            {
                return 0;
            }
        }

    }
}
