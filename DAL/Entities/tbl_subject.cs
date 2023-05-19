using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_subject")]
    public class tbl_subject
    {
        [Key]
        public long subjectid { get; set; }
        public string subjectname { get; set; }
        public long fkclassid { get; set; }
        public DateTime? cr_date { get; set; }
        public long fkschoolid { get; set; }
    }
}
