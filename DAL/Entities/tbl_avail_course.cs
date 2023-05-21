using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_avail_course")]
    public class tbl_avail_course
    {
        [Key]
        public long availcourseid { get; set; }
        public long fkuserid { get; set; }
        public long fkcourseid { get; set; }
        public long fkteacheravailid { get; set; }
        public bool isconfirm { get; set; }
        public string payment { get; set; }
    }
}
