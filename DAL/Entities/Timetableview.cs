using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Timetableview")]
    public class Timetableview
    {
        [Key]
        public long timetableid { get; set; }
        public string nameofday { get; set; }
        public int periodnumber { get; set; }
        public long fkteacherid { get; set; }
        public string firstname { get; set; }
        public long fksubjectid { get; set; }
        public string subjectname { get; set;}
        public long fkclassid { get; set; }
        public string classname { get; set;}
        public string section { get; set; }
        //public long fkschoolid { get; set; }
    }

}
