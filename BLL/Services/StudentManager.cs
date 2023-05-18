using BLL.Helpers;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentManager
    {
        MyDbContext _db = new MyDbContext();
        public List<tbl_users> Studentlist(long FKschoolID)
        {
            int id = Convert.ToInt32(Constant.Student.ToString());
            var item = _db.tbl_users.Where(x => x.fkschoolID == FKschoolID && x.usertype == id && x.isdelete == false).ToList();
            return item;
        }




        public bool CreateStudent(tbl_users model)
        {
            try
            {
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
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateStudent(tbl_users model)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == model.userid);
                if (item != null)
                {
                    item.state = model.state;
                    item.email = model.email;
                    item.isactive = model.isactive;
                    item.address = model.address;
                    item.city = model.city;
                    item.country = model.country;
                    item.pin = model.pin;
                    item.firstname = model.firstname;
                    item.lastname = model.lastname;
                    item.pass = model.pass;
                    item.contact = model.contact;
                    item.sex = model.sex;
                    item.userimage = model.userimage;
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
        public bool DeleteStudent(long UserID)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == UserID);
                if (item != null)
                {
                    item.isdelete = true;
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
