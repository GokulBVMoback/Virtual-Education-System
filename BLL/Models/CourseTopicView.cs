﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CourseTopicView:tbl_course_topic
    {
        public string branchname { get; set; }
    }
}
