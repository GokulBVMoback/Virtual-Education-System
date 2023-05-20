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
    public class SubjectManager
    {
        MyDbContext _db = new MyDbContext();
        public List<Timetableview> Subjectlist(long FKschoolID)
        {

            var item = _db.Timetableview.Where(x => x.fkschoolid == FKschoolID).ToList();
            return item;
        }
        public bool CreateSubject(tbl_subject model)
        {
            try
            {
                tbl_subject sub = new tbl_subject();
                sub.subjectname = model.subjectname;
                sub.cr_date = System.DateTime.Now;
                sub.fkschoolid = Config.CurrentUser;
                sub.fkclassid = model.fkclassid;

                _db.tbl_subject.Add(sub);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteSubject(long subjectid)
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
        public bool UpdateSubject(long subjectid, tbl_subject model)
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
    }
}
