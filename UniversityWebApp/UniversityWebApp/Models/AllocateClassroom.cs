using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWebApp.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DaysId { get; set; }
        public string StartId { get; set; }
        public string EndId { get; set; }
        public int Allocate { get; set; }
    }
}