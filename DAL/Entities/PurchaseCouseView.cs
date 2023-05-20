using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("PurchaseCouseView")]
    public class PurchaseCouseView
    {

        [Key]
        public long availcourseid { get; set; }
        public long fkuserid { get; set; }
        public string coursename { get; set; }
        public string duration { get; set; }
        public string course_desc { get; set; }
        public DateTime? startdate { get; set; }
        public string topicname { get; set; }
        public string branchname { get; set; }
        public string nameofday { get; set; }
        public string timing { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }

    }
}
