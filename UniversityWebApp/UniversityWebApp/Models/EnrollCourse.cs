using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWebApp.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        public int StudentRegId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
    }
}