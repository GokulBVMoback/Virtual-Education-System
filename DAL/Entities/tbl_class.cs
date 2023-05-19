using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_class")]
    public class tbl_class
    {
        [Key]
        public long classid { get; set; }
        public string classname { get; set; }
        public string section { get; set; }
        public DateTime? cr_date { get; set; }
        public long fkschoolid { get; }
    }
}