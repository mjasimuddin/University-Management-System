using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class SaveCourseManager
    {
        SaveCourseGateway _saveCourseGateway = new SaveCourseGateway();
        public string Save(SaveCourse aCourse)
        {
            if (_saveCourseGateway.Check(aCourse))
            {
                return "Course code or name already exists";
            }
            if (aCourse.Code.Length < 5)
            {
                return "Course code must be at least five characters long";
            }
            if (aCourse.Credit < .5 || aCourse.Credit > 5)
            {
                return "Course credit must be at least .5 and at most 5";
            }
            string result = _saveCourseGateway.Save(aCourse);
            return result;
        }
        public List<SaveCourse> GetAllCourses(int id)
        {
            return _saveCourseGateway.GetAllCourses(id);
        }
        public List<SaveCourse> GateCourseDetail(int id)
        {
            return _saveCourseGateway.GateCourseDetail(id);
        }
    }
}