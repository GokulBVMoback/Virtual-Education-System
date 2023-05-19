﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Entities
{
    [Table("UserDisplayView")]
    public class UserDisplay
    {
        [Key]
        public long userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pin { get; set; }
        public string sex { get; set; }
        public string userimage { get; set; }
        public DateTime? cr_date { get; set; }
        public string classname { get; set; }
        public string schoolname { get; set; }
        public string curriculum { get; set; }
    }
}