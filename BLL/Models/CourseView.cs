using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CourseView:tbl_course
    {
        public string courseTopicName { get; set; }
        public string username { get; set; }
    }
}
