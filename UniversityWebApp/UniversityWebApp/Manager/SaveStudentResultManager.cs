using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class SaveStudentResultManager
    {
        SaveStudentResultGateway _saveStudentResultGateway = new SaveStudentResultGateway();

        public List<EnrolledCourseList> GateCourseList(int id)
        {
            return _saveStudentResultGateway.GateCourseList(id);
        }

        public string SaveResult(SaveStubentResult saveStubentResult)
        {
            if (_saveStudentResultGateway.Check(saveStubentResult))
            {
                return "Result already saved";
            }
            return _saveStudentResultGateway.SaveResult(saveStubentResult);
        }
    }
}