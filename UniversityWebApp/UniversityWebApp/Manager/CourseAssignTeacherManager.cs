using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class CourseAssignTeacherManager
    {
        public CourseAssignTeacherGateway _AssignTeacherGateway = new CourseAssignTeacherGateway();
        public string AssignCourseToTeacher(CourseAssignTeacher _courseAssignTeacher)
        {
            if (_AssignTeacherGateway.AssignedOrNot(_courseAssignTeacher))
            {
                return "This course is already assigned";
            }
            _AssignTeacherGateway.UpdateRemainingCredit(_courseAssignTeacher);
            string result = _AssignTeacherGateway.AssignCourseToTeacher(_courseAssignTeacher);

            return result;
        }
    }
}