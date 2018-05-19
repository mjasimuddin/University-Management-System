using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class DesignationTeacherManager
    {
        DesignationTeacherGateway _gateway = new DesignationTeacherGateway();
        public List<DesignationTeacher> GetAllDesignation()
        {
            return _gateway.GetAllDesignation();
        }
    }
}