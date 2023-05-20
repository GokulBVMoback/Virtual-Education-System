using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_teacher_availability")]
    public class tbl_teacher_availability
    {
        [Key]
        public long teacheravailid { get; set; }
        public string nameofday { get; set; }
        public string timing { get; set; }
     
        public long fkuserid { get; set; }
        public DateTime cr_date { get; set; }
                
    }
}
