
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tutoring.Models
{
    public class Student_Reg
    {
        public string email { get; set; }
        public string pass { get; set; }
        public int usertype { get; set; }

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
        public string sex { get; set; }


        public long fkuserId { get;set; }
        public long fkclassId { get; set; }
       
        public string fatherName { get; set; }
        public string motherName { get;set; }

    }
}