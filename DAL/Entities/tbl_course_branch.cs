using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_corse_branch")]
    public class tbl_course_branch
    {
        [Key]
        public long coursebranchid { get; set; }
        public string branchname { get; set; }
        public DateTime? cr_date { get; set; }
    }
}
