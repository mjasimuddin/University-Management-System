using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class GradeManager
    {
        GradeGateway _gradeGateway = new GradeGateway();
        public List<Grade> GetAllGrades()
        {
            return _gradeGateway.GetAllGrades();
        }
    }
}