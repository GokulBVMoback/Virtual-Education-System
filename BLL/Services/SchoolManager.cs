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
    public class SchoolManager
    {
        MyDbContext _db = new MyDbContext();
        public List<tbl_class> Classlist(long FKschoolID)
        {

            var item = _db.tbl_class.Where(x => x.fkschoolid == FKschoolID).ToList();
            return item;
        }
        public bool CreateClass(tbl_class model)
        {
            try
            {
                tbl_class users = new tbl_class();
                users.classname = model.classname;
                users.section = model.section;
                users.cr_date = System.DateTime.Now;
                users.fkschoolid = Config.CurrentUser;

                _db.tbl_class.Add(users);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteClass(long classid)
        {
            try
            {
                var item = _db.tbl_class.FirstOrDefault(x => x.classid == classid);
                if (item != null)
                {
                    _db.tbl_class.Remove(item);
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
        public bool UpdateClass(tbl_class model)
        {
            try
            {
                var item = _db.tbl_class.FirstOrDefault(x => x.classid == model.classid);
                if (item != null)
                {
                    item.classname = model.classname;
                    item.section = model.section;

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

        public long CreateSchool(tbl_school model)
        {
            try
            {
                tbl_school school = new tbl_school();
                school.schoolname = model.schoolname;
                school.address = model.address;
                school.city = model.city;
                school.state = model.state;
                school.country = model.country;
                school.curriculum = model.curriculum;
                school.pin = model.pin;
                school.contact = model.contact;
                school.isactive = true;
                school.cr_date = DateTime.Now;
                school.isdelete = false;
                school.fkuserid = model.fkuserid;
                school.schoolname=model.schoolname;

                _db.tbl_school.Add(school);
                _db.SaveChanges();
                var id = school.schoolid;
                return id;
            }
            catch
            {
                return 0;
            }

        }
    }
}
