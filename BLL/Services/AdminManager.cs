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
    public class AdminManager
    {
        MyDbContext _db = new MyDbContext();

        public List<tbl_school> GetSchool()
        {
            return _db.tbl_school.Where(x=>x.isdelete==false).ToList();
        }

        public List<tbl_users> GetIndividualTeachers()
        {
            return _db.tbl_users.Where(x=>x.usertype==3 && x.fkschoolID==0 && x.isdelete == false).ToList();
        }

        public List<tbl_users> GetIndividualStudents()
        {
            return _db.tbl_users.Where(x => x.usertype == 4 && x.fkschoolID == 0 && x.isdelete == false).ToList();
        }

        public List<tbl_course_branch> GetCourseBranch()
        {
            return _db.tbl_course_branch.ToList();
        }

        public List<tbl_course_topic> GetCourseTopic()
        {
            return _db.tbl_course_topic.ToList();
        }

        public List<tbl_course> GetAllCourse()
        {
            return _db.tbl_course.ToList();
        }

        public List<tbl_subject> GetSubject()
        {
            return _db.tbl_subject.ToList();
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

        public tbl_course GetCourse(long courseid)
        {
            return _db.tbl_course.Where(x=>x.courseid==courseid).FirstOrDefault();
        }

        public bool UpdateUser(tbl_users model)
        {
            try
            {

                var item = _db.tbl_users.FirstOrDefault(x => x.userid == model.userid);
                var checkExistEmail = _db.tbl_users.Where(x => x.userid != model.userid && x.email == model.email).FirstOrDefault();
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

        public bool UpdateSchool(string SchoolName, string Curriculum, long SchoolId, tbl_users model)
        {
            try
            {
                var item = _db.tbl_school.FirstOrDefault(x => x.schoolid == SchoolId);
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

        public bool UpdateBranch(tbl_course_branch model)
        {
            try
            {
                var item = _db.tbl_course_branch.FirstOrDefault(x => x.coursebranchid == model.coursebranchid);
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

        public bool UpdateTopic(tbl_course_topic model)
        {
            try
            {
                var item = _db.tbl_course_topic.FirstOrDefault(x => x.coursetopicid == model.coursetopicid);
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

        public bool UpdateSubject(tbl_subject model)
        {
            try
            {
                var item = _db.tbl_subject.FirstOrDefault(x => x.subjectid == model.subjectid);
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

        public bool DeleteSchool(long SchoolID)
        {
            try
            {
                var item = _db.tbl_school.FirstOrDefault(x => x.schoolid == SchoolID);
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

        public bool DeleteBranch(long BranchID)
        {
            try
            {
                var item = _db.tbl_course_branch.FirstOrDefault(x => x.coursebranchid == BranchID);
                if (item != null)
                {
                    _db.tbl_course_branch.Remove(item);
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

    }
}
