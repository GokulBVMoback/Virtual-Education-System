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
    [Table("tbl_course")]
    public class tbl_course
    {
        [Key]
        public long courseid { get; set; }
        public string coursename { get; set; }
        public string duration { get; set; }
        public string coursefee { get; set; }
        public string course_desc { get; set; }
        public DateTime? startdate { get; set; }
        public long fk_coursetopicid { get; set; }
        public DateTime? cr_date { get; set; }
        public long fkuserid { get; set; }

    }
}
