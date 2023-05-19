using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("SubjectView")]
   
    public class SubjectView/* :tbl_subject*/
    {
        [Key]
        public long subjectid { get; set; }
        public string subjectname { get; set; }
        public long classid { get; set; }
        public string classname { get; set; }
        public string section { get; set; }
        public string schoolname { get; set; }
        public long schoolid { get; set; }


        //public string classname { get; set; }
        //public string schoolname { get; set; }
    }
}
