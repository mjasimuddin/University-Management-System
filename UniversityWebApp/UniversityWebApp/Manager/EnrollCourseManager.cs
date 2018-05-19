using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway _enrollCourseGateway = new EnrollCourseGateway();
        public string SaveEnroll(EnrollCourse _enrollCourse)
        {
            if (_enrollCourseGateway.Check(_enrollCourse))
            {
                return "This course is already taken with this Registration No.";
            }
            return _enrollCourseGateway.SaveEnroll(_enrollCourse);

        }
    }
}