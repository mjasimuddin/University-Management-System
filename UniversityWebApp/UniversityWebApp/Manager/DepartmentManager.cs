using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway _departmentGateway = new DepartmentGateway();
        public string Save(Department aDepartment)
        {
            if (_departmentGateway.Check(aDepartment))
            {
                return "Department code or name already exists";
            }
            if (aDepartment.Code.Length < 2 || aDepartment.Code.Length > 7)
            {
                return "Department code must be two to seven characters long";
            }
            string result = _departmentGateway.Save(aDepartment);
            return result;
        }
        public List<Department> GetAllDepartment()
        {
            return _departmentGateway.GetAllDepartment();
        }
    }
}