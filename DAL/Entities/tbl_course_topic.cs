using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_course_topic")]
    public class tbl_course_topic
    {
        [Key]
        public long coursetopicid { get; set; }
        public string topicname { get; set; }
        public long fk_coursebranchid { get; set; }
        public DateTime? cr_date { get; set; }
    }
}