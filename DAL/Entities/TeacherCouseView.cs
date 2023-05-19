using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("TeacherCouseView")]
    public class TeacherCouseView
    {
        [Key]
        public long availcourseid { get; set; }
        public long fkuserid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string coursename { get; set; }
        public string payment { get; set; }
        public long fkschoolID { get; set; }


}
}
