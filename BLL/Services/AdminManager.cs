using Amazon.S3.Model;
using BLL.Helpers;
using BLL.Models;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Services
{
    public class AdminManager
    {
        MyDbContext _db = new MyDbContext();

        public List<SchoolView> GetSchool()
        {
            List<SchoolView> result = (from school in _db.tbl_school
                                       join user in _db.tbl_users on school.fkuserid equals user.userid
                                       orderby school.schoolid
                                       select new SchoolView
                                       {
                                           schoolid = school.schoolid,
                                           schoolname = school.schoolname,
                                           contact = school.contact,
                                           address = school.address,
                                           city = school.city,
                                           state = school.state,
                                           country = school.country,
                                           pin = school.pin,
                                           isactive = school.isactive,
                                           username = user.firstname+" "+user.lastname,
                                           curriculum = school.curriculum
                                       }).ToList();
            return result;
        }

        public List<tbl_users> GetIndividualTeachers()
        {
            return _db.tbl_users.Where(x=>x.usertype==3 && x.fkschoolID==0 && x.isdelete == false).ToList();
        }

        public List<tbl_student> GetIndividualStudents()
        {
            return _db.tbl_student.Where(x => x.fkschoolid == 0).ToList();
        }

        public List<tbl_course_branch> GetCourseBranch()
        {
            return _db.tbl_course_branch.ToList();
        }

        public List<CourseTopicView> GetCourseTopic()
        {
            List<CourseTopicView> result = (from topic in _db.tbl_course_topic
                                        join branch in _db.tbl_course_branch on topic.fk_coursebranchid equals branch.coursebranchid
                                        orderby topic.coursetopicid
                                        select new CourseTopicView
                                        {
                                            coursetopicid=topic.coursetopicid,
                                            topicname = topic.topicname,
                                            branchname = branch.branchname
                                        }).ToList();
            return result;
        }

        public List<CourseView> GetAllCourse()
        {
            List<CourseView> result = (from course in _db.tbl_course
                                       join topic in _db.tbl_course_topic on course.fk_coursetopicid equals topic.coursetopicid
                                       orderby course.courseid
                                       select new CourseView
                                       {
                                           courseid = course.courseid,
                                           coursename = course.coursename,
                                           duration = course.duration,
                                           coursefee = course.coursefee,
                                           course_desc = course.course_desc,
                                           startdate = course.startdate,
                                           courseTopicName = topic.topicname
                                       }).ToList();
            return result;
        }

        public List<SubjectView> GetSubject()
        {
            List<SubjectView> result = (from subject in _db.tbl_subject
                                       join school in _db.tbl_school on subject.fkschoolid equals school.schoolid
                                       join tblclass in _db.tbl_class on subject.fkclassid equals tblclass.classid
                                       orderby subject.subjectid
                                       select new SubjectView
                                       {
                                           subjectid = subject.subjectid,
                                           subjectname = subject.subjectname,
                                           classname=tblclass.classname,
                                           schoolname= school.schoolname
                                       }).ToList();
            return result;
        }

        public List<tbl_users> GetUsers()
        {
            return _db.tbl_users.ToList();
        }

        public bool CreateUser(tbl_users model)
        {
            try
            {
                var email=_db.tbl_users.Where(x=>x.email==model.email).FirstOrDefault();
                if (email == null)
                {
                    tbl_users user = new tbl_users();
                    user.email = model.email;
                    user.usertype = 2;
                    user.firstname = model.firstname;
                    user.lastname = model.lastname;
                    user.sex = model.sex;
                    user.userimage = model.userimage;
                    user.pass = model.pass;
                    user.state = model.state;
                    user.fkschoolID = model.userid;
                    user.isactive = model.isactive;
                    user.address = model.address;
                    user.city = model.city;
                    user.country = model.country;
                    user.contact = model.contact;
                    user.cr_date = System.DateTime.Now;
                    user.pin = model.pin;
                    _db.tbl_users.Add(user);
                    _db.SaveChanges();
                    Config.SchoolUser= user;
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

        public bool CreateSchool(string SchoolName, string Curriculum, tbl_users model)
        {
            try
            {
                tbl_school school = new tbl_school();
                school.state = model.state;
                school.schoolname = SchoolName;
                school.fkuserid = model.userid;
                school.isactive = model.isactive;
                school.address = model.address;
                school.city = model.city;
                school.country = model.country;
                school.contact = model.contact;
                school.cr_date = System.DateTime.Now;
                school.curriculum = Curriculum;
                school.pin = model.pin;
                _db.tbl_school.Add(school);
                _db.SaveChanges();
                var user=_db.tbl_users.Where(x=>x.userid==model.userid).FirstOrDefault();
                user.fkschoolID= school.schoolid;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateBranch(tbl_course_branch model)
        {
            try
            {
                tbl_course_branch branch = new tbl_course_branch();
                branch.branchname = model.branchname;
                branch.cr_date=System.DateTime.Now;
                _db.tbl_course_branch.Add(branch);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateTopic(tbl_course_topic model)
        {
            try
            {
                tbl_course_topic topic = new tbl_course_topic();
                topic.topicname = model.topicname;
                topic.fk_coursebranchid = model.fk_coursebranchid;
                topic.cr_date = System.DateTime.Now;
                _db.tbl_course_topic.Add(topic);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CourseView GetCourse(long courseid)
        {
            CourseView result = (from course in _db.tbl_course
                                       join topic in _db.tbl_course_topic on course.fk_coursetopicid equals topic.coursetopicid
                                       join user in _db.tbl_users on course.fkuserid equals user.userid
                                       orderby course.courseid
                                       where course.courseid == courseid
                                       select new CourseView
                                       {
                                           courseid = course.courseid,
                                           coursename = course.coursename,
                                           duration = course.duration,
                                           coursefee = course.coursefee,
                                           course_desc = course.course_desc,
                                           startdate = course.startdate,
                                           courseTopicName = topic.topicname,
                                           username=user.firstname+" "+user.lastname
                                       }).FirstOrDefault();
            return result;
        }

        public bool UpdateUser(long userid,tbl_users model)
        {
            try
            {

                var item = _db.tbl_users.FirstOrDefault(x => x.userid == userid);
                var checkExistEmail = _db.tbl_users.Where(x => x.userid != userid && x.email == model.email).FirstOrDefault();
                if (item != null && checkExistEmail == null)
                {
                    item.contact = model.contact;
                    item.address = model.address;
                    item.email = model.email;
                    item.firstname = model.firstname;
                    item.lastname = model.lastname;
                    item.city = model.city;
                    item.state = model.state;
                    item.country = model.country;
                    item.pin = model.pin;
                    item.sex = model.sex;
                    item.userimage = model.userimage;
                    item.isactive = model.isactive;
                    item.up_date = System.DateTime.Now;
                    _db.SaveChanges();
                    Config.SchoolUser = item;
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

        public bool UpdateSchool(string SchoolName, string Curriculum, tbl_users model)
        {
            try
            {
                var item = _db.tbl_school.FirstOrDefault(x => x.fkuserid == model.userid);
                if (item != null)
                {
                    item.schoolname = SchoolName;
                    item.address = model.address;
                    item.city = model.city;
                    item.contact = model.contact;
                    item.country = model.country;
                    item.curriculum = Curriculum;
                    item.pin = model.pin;
                    item.state = model.state;
                    item.isactive = model.isactive;
                    item.up_date = System.DateTime.Now;
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

        public bool UpdateBranch(long branchid, tbl_course_branch model)
        {
            try
            {
                var item = _db.tbl_course_branch.FirstOrDefault(x => x.coursebranchid == branchid);
                if (item != null)
                {
                    item.branchname = model.branchname;
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

        public bool UpdateTopic(long topicid, tbl_course_topic model)
        {
            try
            {
                var item = _db.tbl_course_topic.FirstOrDefault(x => x.coursetopicid == topicid);
                if (item != null)
                {
                    item.topicname = model.topicname;
                    item.fk_coursebranchid = model.fk_coursebranchid;
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

        public bool UpdateSubject(long subjectid,tbl_subject model)
        {
            try
            {
                var item = _db.tbl_subject.FirstOrDefault(x => x.subjectid == subjectid);
                if (item != null)
                {
                    item.subjectname = model.subjectname;
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

        public bool UpdateIndividualStudent(tbl_student student,tbl_users model)
        {
            try
            {
                var item = _db.tbl_student.FirstOrDefault(x => x.fkuserid == model.userid);
                if (item != null)
                {
                    item.firstname = model.firstname;
                    item.lastname = model.lastname;
                    item.fathername = student.fathername;
                    item.mothername = student.mothername;
                    item.sex= model.sex;
                    item.contact = model.contact;
                    item.email = model.email;
                    item.address = model.address;
                    item.city = model.city;
                    item.state = model.state;
                    item.country = model.country;
                    item.pin = model.pin;
                    item.fkschoolid = student.fkschoolid;
                    item.fkclassid=student.fkclassid;
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

        public bool DeleteUser(long UserID)
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

        public bool DeleteSchool(long fkuserid)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == fkuserid && x.usertype==2);
                var item2 = _db.tbl_school.FirstOrDefault(x => x.fkuserid == fkuserid);
                if (item != null)
                {
                    item.isdelete = true;
                    _db.SaveChanges();
                    item2.isdelete = true;
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

        public bool DeleteIndividualTeacher(long userID)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == userID && x.usertype == 3 && x.fkschoolID==0);
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

        public bool DeleteIndividualStudent(long userID)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == userID && x.usertype == 4 && x.fkschoolID==0);
                var item2 = _db.tbl_student.FirstOrDefault(x=>x.fkuserid==userID);
                if (item2 != null)
                {
                    item.isdelete = true;
                    _db.tbl_student.Remove(item2);
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

        public bool DeleteBranch(long subjectid)
        {
            try
            {
                var item = _db.tbl_subject.FirstOrDefault(x => x.subjectid == subjectid);
                if (item != null)
                {
                    _db.tbl_subject.Remove(item);
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

        public bool DeleteTopic(long TopicID)
        {
            try
            {
                var item = _db.tbl_course_topic.FirstOrDefault(x => x.coursetopicid == TopicID);
                if (item != null)
                {
                    _db.tbl_course_topic.Remove(item);
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

        public bool DeleteSubject(long SubjectID)
        {
            try
            {
                var item = _db.tbl_subject.FirstOrDefault(x => x.subjectid == SubjectID);
                if (item != null)
                {
                    _db.tbl_subject.Remove(item);
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

        public bool ChangeUserActiveStatus(long userid)
        {
            try
            {
                var item = _db.tbl_users.FirstOrDefault(x => x.userid == userid);
                if (item != null)
                {
                    if(item.usertype==2)
                    {
                        var item2 = _db.tbl_school.FirstOrDefault(x => x.fkuserid == userid);
                        item2.isactive = !(item2.isactive == true) ? false : true;
                        _db.SaveChanges();
                    }
                    item.isactive=item.isactive == true ? false : true;
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

        public bool ChangeSchoolActiveStatus(long schoolid)
        {
            try
            {
                var item = _db.tbl_school.FirstOrDefault(x => x.schoolid == schoolid);
                if (item != null)
                {
                    item.isactive = item.isactive == true ? false : true;
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
