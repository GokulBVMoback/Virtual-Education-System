using BLL.Helpers;
using BLL.Models;
using DAL.Entities;
using DAL.MasterEntity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ThirdParty.BouncyCastle.Math;

namespace BLL.Services
{
    public class TeacherManager
    {
        MyDbContext _db = new MyDbContext();


        /// <summary>
        /// crud for teacher
        /// </summary>
        /// <param name="FKschoolID"></param>
        /// <returns></returns>

        //Retrieve
        public List<tbl_users> TeacherList(long FKschoolID)
        {
            int id = Convert.ToInt32(Constant.Teacher.ToString());
            var item = _db.tbl_users.Where(x => x.fkschoolID == FKschoolID && x.usertype == id && x.isdelete == false).ToList();
            return item;
        }

        //create
        public bool CreateTeacher(tbl_users model)
        {
            try
            {
                tbl_users users = new tbl_users();
                users.state = model.state;
                users.email = model.email;
                users.isactive =true;
                users.address = model.address;
                users.city = model.city;
                users.country = model.country;
                users.pin = model.pin;
                users.cr_date =DateTime.Now;
                users.firstname = model.firstname;
                users.lastname = model.lastname;
                users.pass = model.pass;
                users.contact = model.contact;
                users.fkschoolID = Config.CurrentUser;
                users.usertype = Convert.ToInt32(Constant.Teacher.ToString());
                users.sex = model.sex;
                users.userimage = model.userimage;
                _db.tbl_users.Add(users);
                _db.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        //update
        public bool UpdateTeacher(tbl_users model)
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

        //delete
        public bool DeleteTeacher(long UserID)
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

        //.........................................................................................................//
        /// <summary>
        /// crud for courses
        /// </summary>
        /// <param name="FKuserId"></param>
        /// <returns></returns>

        //Retrive
        public List<DAL.Entities.CourseView> CouserList()
        {
            var result = _db.courseView.Where(x=>x.fkuserid==Config.CurrentUser).ToList();
            return result;
        }

        //Create
        public bool CreateCourse(tbl_course model)
        {
            try
            {
                tbl_course course = new tbl_course();
                course.coursename=model.coursename;
                course.duration= model.duration;
                course.coursefee= model.coursefee;
                course.course_desc = model.course_desc;
                course.startdate =model.startdate;
                course.fkuserid = Config.CurrentUser;
                course.cr_date=System.DateTime.Now;
                course.fk_coursetopicid= model.fk_coursetopicid;
                _db.tbl_course.Add(course);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //update
        public bool UpdateCourse(tbl_course model)
        {
            try
            {
                var item = _db.tbl_course.FirstOrDefault(x => x.courseid == model.courseid);
                if (item != null)
                {
                    item.coursename = model.coursename;
                    item.duration = model.duration;
                    item.coursefee = model.coursefee;
                    item.course_desc = model.course_desc;
                    item.startdate = model.startdate;
                    item.fk_coursetopicid= model.fk_coursetopicid;
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

        //delete
        public bool DeleteCourse(long courseid)
        {
            try
            {
                var item = _db.tbl_course.FirstOrDefault(x => x.courseid == courseid);
                if (item != null)
                {
                    _db.tbl_course.Remove(item);
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

        //...............................................................................................................//

        /// <summary>
        /// crud for time table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 

        //retrieve
        public List<Timetableview> Timetable(long userid,DateTime currentDate)
        {
            var result = _db.Timetableview.Where(s=>s.fkteacherid== userid).ToList();
            return result;
        }

        //create
        public bool CreateTimetable(tbl_timetable model)
        {
            try
            {
               

                tbl_timetable timetable = new tbl_timetable();
                timetable.nameofday=model.nameofday;
                timetable.periodnumber=model.periodnumber;
                timetable.fkteacherid = Config.CurrentUser;
                timetable.fksubjectid = model.fksubjectid;  
                timetable.fkclassid=model.fkclassid;
                timetable.fkschoolid = Config.User.fkschoolID;
                timetable.cr_date=System.DateTime.Now;
                _db.tbl_timetable.Add(timetable);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //update
        public bool UpdateTimetable(tbl_timetable model)
        {
            try
            {
                var item = _db.tbl_timetable.FirstOrDefault(x => x.timetableid == model.timetableid);
                if (item != null)
                {
                    item.nameofday = model.nameofday;
                    item.periodnumber = model.periodnumber;
                    item.fksubjectid = model.fksubjectid;   
                    item.fkclassid = model.fkclassid;
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

        //delete
        public bool DeleteTimetable(long timetableid)
        {
            try
            {
                var item = _db.tbl_timetable.FirstOrDefault(x => x.timetableid == timetableid);
                if (item != null)
                {
                    _db.tbl_timetable.Remove(item);
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

        //......................................................................................................................//
        /// <summary>
        /// Retrieve student details
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
       
        //for School Teacher
        public List<tbl_users> GetStudent(long schoolid)
        {
            List<tbl_users> students = _db.tbl_users.Where(s => s.fkschoolID == schoolid && s.usertype==4).ToList();
            return students;
        }

        //for Individual teacher
        public List<TeacherCouseView>GetCourseStudent(long schoolid)
        {
            List<TeacherCouseView>courseStudent=_db.teacherCouseViews.Where(s=>s.fkuserid==Config.CurrentUser).ToList();
            return courseStudent;
        }


        //......................................................................................................................//

        //Profile Retreive
        public tbl_users TeacherProfile(long userid)
        {
            var result = _db.tbl_users.Where(a=>a.userid==userid).FirstOrDefault();
            return result;
        }

        //.....................................................................................................................................//

        //subject Retreive
        public List<DAL.Entities.SubjectView> GetSubjects(long schoolid)
        {
            List<DAL.Entities.SubjectView> sub = _db.subjectView.Where(s => s.schoolid == schoolid).ToList();
            return sub;
        }

        //.....................................................................................................................................//
    }
}
