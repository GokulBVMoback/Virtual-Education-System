using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SubjectView:tbl_subject
    {
        public string classname { get; set; }

        public string schoolname { get; set; }
    }
}
