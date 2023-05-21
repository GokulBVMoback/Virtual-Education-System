using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ClassSubject")]
    public class ClassSubject
    {
        [Key]
        public long classid { get; set; }
        public string classname { get; set; }
        public string section { get; set; }
        public long subjectid { get; set; }
        public string subjectname { get; set; }
        public long fkschoolid { get; set; }
        
    }
}
