using BLL.Helpers;
using DAL.Entities;
using DAL.MasterEntity;
using Microsoft.AspNet.Identity;
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
        public bool ChangePassword(string password)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == Config.CurrentUser);
                if (item != null)
                {
                    item.pass = password;
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
        public UserDisplay Getuser(string email)
        {
            UserDisplay result = _db.UserDisplay.Where(x => x.email == email).FirstOrDefault();
            return result;
        }

        public long Createstudent(tbl_student model)
        {
            try
            {
                tbl_student student = new tbl_student();
                student.firstname = model.firstname;
                student.lastname = model.lastname;
                student.fatherName = model.fatherName;
                student.motherName = model.motherName;

                student.contact = model.contact;
                student.address = model.address;
                student.city = model.city;
                student.state = model.state;
                student.country = model.country;
                student.pin = model.pin;
                // student.fkschoolID = model.fkschoolID;
                // student.isactive = true;
                // student.cr_date = DateTime.Now;
              //  student.contact = model.contact;
              //  student.address = model.address;
               // student.city = model.city;
               // student.state = model.state;
                //student.country = model.country;
                //student.pin = model.pin;
                //student.lastname = model.lastname;
               // student.firstname = model.firstname;
               // student.motherName = model.motherName;
               // student.fatherName = model.fatherName;
                student.cr_date = DateTime.Now;
               // student.isdelete = false;
                student.fkuserid = model.fkuserid;
                student.fkclassid = model.fkclassid;
                student.fkschoolid = model.fkschoolid;
                // student.sex = model.sex;

                student.sex = model.sex;
               // student.usertype = model.usertype;
                student.email = model.email;
                //  student.pass = model.pass;



                _db.tbl_student.Add(student);
                _db.SaveChanges();
                var id = student.studentid;
                return id;
            }
            catch
            {
                return 0;
            }
        }

    }
}