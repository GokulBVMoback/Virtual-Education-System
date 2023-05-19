using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty.BouncyCastle.Math;

namespace DAL.Entities
{
    [Table("tbl_timetable")]
    public class tbl_timetable
    {
        [Key]
        public long timetableid { get; set; }
        public string nameofday { get; set; }
        public int periodnumber { get; set; }
        public long fkteacherid { get; set; }
        public long fksubjectid { get; set; }
        public long fkclassid { get; set; }
        public long fkschoolid { get; set; }
        public DateTime? cr_date { get; set; }
    }
}
