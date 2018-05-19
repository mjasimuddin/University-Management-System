using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class StudentRegistrationManager
    {
        StudentRegistrationGateway _studentRegistrationGateway = new StudentRegistrationGateway();
        public string Register(StudentRegistration aStudentRegistration)
        {
            if (_studentRegistrationGateway.Check(aStudentRegistration))
            {
                return "Your email already exists";
            }
            string RegNo = _studentRegistrationGateway.GenerateRegNo(aStudentRegistration);
            aStudentRegistration.RegNo = RegNo;
            string result = _studentRegistrationGateway.Register(aStudentRegistration);
            return result;
        }

        public StudentRegistration LastStudent()
        {
            StudentRegistration lastStudent = _studentRegistrationGateway.LastStudent();

            return lastStudent;
        }
        public List<StudentRegistration> GetRegStudentList(int id)
        {
            return _studentRegistrationGateway.GetRegStudentList(id);
        }
        public List<StudentRegistration> GetStudentDetails(int id)
        {
            return _studentRegistrationGateway.GetStudentDetails(id);
        }
    }
}