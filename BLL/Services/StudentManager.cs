using BLL.Helpers;
using DAL.Entities;
using DAL.MasterEntity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var user = _db.tbl_students.FirstOrDefault(x => x.fkuserid == Config.CurrentUser);
            var item = _db.Timetableview.Where(x => x.fkschoolid == FKschoolID && x.fkclassid == user.fkclassid && x.nameofday == currentDate.DayOfWeek.ToString()).ToList();
            return item;
        }

        public List<SubjectView> SubjectViews(long FkSchoolId)
        {
            try
            {
                if (FkSchoolId != 0)
                {
                    var user = _db.tbl_students.FirstOrDefault(x => x.fkuserid == Config.CurrentUser);
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
    }
}
