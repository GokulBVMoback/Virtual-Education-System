using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tbl_users")]
    public class tbl_users
    {

        [Key]
        public long userid { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public int? usertype { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pin { get; set; }
        public long fkschoolID { get; set; }
        public bool isactive { get; set; }
        public DateTime? cr_date { get; set; }
        public DateTime? up_date { get; set; }
        public bool isdelete { get; set; }
        public string sex { get; set; }
        public string userimage { get; set; }
    }
}
