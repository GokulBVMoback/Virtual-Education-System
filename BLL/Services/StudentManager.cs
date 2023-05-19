using BLL.Helpers;
using BLL.Models;
using DAL.Entities;
using DAL.MasterEntity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseView = DAL.Entities.CourseView;
using SubjectView = DAL.Entities.SubjectView;

namespace BLL.Services
{
    public class StudentManager
    {
        MyDbContext _db = new MyDbContext();

        //------------------School Student Method start Here ------------------------
        public UserDisplay GetSchoolStudentDetails(int id)
        {
            try
            {
                UserDisplay result = _db.UserDisplay.Where(x => x.userid == id).FirstOrDefault();
                return result;
            }
            catch { return null; }
        }
        public List<Timetableview> TimetableForSchoolStudent(long FKschoolID, DateTime currentDate)
        {
            var user = _db.tbl_student.FirstOrDefault(x => x.fkuserid == Config.CurrentUser);
            var item = _db.Timetableview.Where(x => x.fkschoolid == FKschoolID && x.fkclassid == user.fkclassid && x.nameofday == currentDate.DayOfWeek.ToString()).ToList();
            return item;
        }

        public List<SubjectView> SubjectViews(long FkSchoolId)
        {
            try
            {
                if (FkSchoolId != 0)
                {
                    var user = _db.tbl_student.FirstOrDefault(x => x.fkuserid == Config.CurrentUser);
                    long id = user.fkclassid;
                    var item = _db.subjectView.Where(x => x.schoolid == FkSchoolId && x.classid == user.fkclassid).ToList();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<TeacherViewForStudent> TeacherViewForStudent()
        {
            var item = _db.teacherViewForIndividualStudents.ToList();
            return item;
        }
        //-----------------School Student Method End Here ---------------------

        //-------------------Individual Student Method start Here --------------------
        public IndividualStudent GetIndividualStudentDetails(long id)
        {
            try
            {
                IndividualStudent individualStudent = _db.individualStudents.Where(x => x.userid == id).FirstOrDefault();
                return individualStudent;
            }
            catch { return null; }
        }
        public List<CourseView> courseViews()
        {
            var item = _db.CourseView.ToList();
            return item;
        }
        public List<TeacherViewForStudent> TeacherViewForIndividualStudents()//TeacherViewForIndividualStudents
            {
                  var item = _db.teacherViewForIndividualStudents.ToList();
                 return item;
            }

        public List<Timetableview> TimetableForIndividualStudent(long FKschoolID,DateTime currentDate)
        {
            if (FKschoolID == 0)
            {
                var item = _db.Timetableview.Where(x => x.fkschoolid == 0 && x.nameofday==currentDate.DayOfWeek.ToString()).ToList();
                return item;
            }
            else
            {
                return null;
            }
        }

        public List<PurchaseCouseView>indSt(long id)
        {
            try
            {
                var  result=_db.purchaseCouseViews.Where(i=>i.fkuserid == id).ToList();
                    return result;
            }
            catch { return null; }
        }
        ////-------------------Individual Student Method End Here ---------------------------
        public bool ChangePassword(ChangePassword newpassword)
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
