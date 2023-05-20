using BLL.Helpers;
using DAL.Entities;
using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicess
{
    public class TimetableManager
    {
        MyDbContext _db = new MyDbContext();
        public List<Timetableview> timetablelist(long FKschoolID)
        {
            var item=_db.Timetableview.Where(x => x.fkschoolid == FKschoolID).ToList();
            return item;

        }
        public bool CreateTimetable(tbl_timetable model)
        {
            try
            {
                tbl_timetable timetable= new tbl_timetable();

                timetable.nameofday = model.nameofday;
                timetable.fkteacherid = model.fkteacherid;
                timetable.fksubjectid = model.fksubjectid;
                timetable.cr_date = System.DateTime.Now;
                timetable.fkschoolid = Config.CurrentUser;
                timetable.fkclassid = model.fkclassid;
                timetable.periodnumber= model.periodnumber;

                _db.tbl_timetable.Add(timetable);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        public bool Updatetimetable(long timetableid, tbl_timetable model)
        {
            try
            {
                var item = _db.tbl_timetable.FirstOrDefault(x => x.timetableid == timetableid);
                if (item != null)
                {
                    item.nameofday = model.nameofday;
                    item.fkclassid = model.fkclassid;
                    item.fkteacherid = model.fkteacherid;
                    item.fksubjectid = model.fksubjectid;
                    item.cr_date= System.DateTime.Now;
                    item.periodnumber= model.periodnumber;
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
    }
}
