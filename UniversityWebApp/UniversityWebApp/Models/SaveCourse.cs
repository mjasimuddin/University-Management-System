﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWebApp.Models
{
    public class SaveCourse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int Semester { get; set; }
    }
}