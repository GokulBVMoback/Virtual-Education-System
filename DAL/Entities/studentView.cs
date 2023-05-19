using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("studentView")]
    public class studentView
    {
        [Key]
        public long studentid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string sex { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public long fkschoolid { get; set; }
        public long fkclassid { get; set; }
    }
}
