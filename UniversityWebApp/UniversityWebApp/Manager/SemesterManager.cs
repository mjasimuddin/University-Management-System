using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class SemesterManager
    {
        SemesterGateway _semesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemesters()
        {
            return _semesterGateway.GetAllSemesters();
        }
    }
}