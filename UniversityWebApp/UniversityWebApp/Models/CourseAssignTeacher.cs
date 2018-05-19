using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWebApp.Models
{
    public class CourseAssignTeacher
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public double CourseCredit { get; set; }
    }
}