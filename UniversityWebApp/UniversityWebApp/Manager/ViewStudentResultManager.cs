using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class ViewStudentResultManager
    {
        ViewStudentResultGateway _studentResultGateway = new ViewStudentResultGateway();

        public List<ViewStudentResult> GetAllResults(int id)
        {
            return _studentResultGateway.GetAllResults(id);
        }
    }
}