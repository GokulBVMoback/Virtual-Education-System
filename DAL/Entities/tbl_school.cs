using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_school")]
    public class tbl_school
    {
        [Key]
        public long schoolid { get; set; }
        public string schoolname { get; set; }
        public string contact { get; set; }        
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pin { get; set; }
        public bool isactive { get; set; }
        public DateTime? cr_date { get; set; }
        public DateTime? up_date { get; set; }
        public bool isdelete { get; set; }
        public long fkuserid { get; set; }
        public string curriculum { get; set; }
    }


}
