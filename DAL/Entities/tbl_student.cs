using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    

    [Table("tbl_student")]
    public class tbl_student
    {
        //tbl_school school=new tbl_school();
        [Key]
        public long studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fathername { get; set; }
        public string mothername { get; set; }
        public string sex { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pin { get; set; }
        public long fkuserid { get; set; }
        public DateTime? cr_date { get; set; }
        public long fkschoolid { get; set; }
        public long fkclassid { get; set; }
    }
}
