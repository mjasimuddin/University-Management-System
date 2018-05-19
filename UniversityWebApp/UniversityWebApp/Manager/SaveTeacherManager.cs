using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class SaveTeacherManager
    {
        SaveTeacherGateway _saveTeacherGateway = new SaveTeacherGateway();
        public string Save(SaveTeacher aTeacher)
        {
            if (_saveTeacherGateway.Check(aTeacher))
            {
                return "Your email already exists";
            }
            if (aTeacher.Credit < 0)
            {
                return "Credit must be a positive number";
            }
            string result = _saveTeacherGateway.Save(aTeacher);
            return result;
        }
        public List<SaveTeacher> GetAllTeachers(int id)
        {
            return _saveTeacherGateway.GetAllTeachers(id);
        }
        public List<SaveTeacher> GetAllteacherDetais(int id)
        {
            return _saveTeacherGateway.GetAllteacherDetais(id);
        }
    }
}