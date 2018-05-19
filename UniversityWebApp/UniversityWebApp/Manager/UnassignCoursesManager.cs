using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;

namespace UniversityWebApp.Manager
{
    public class UnassignCoursesManager
    {
        UnassignCoursesGateway _unassignCoursesGateway = new UnassignCoursesGateway();
        public string Unassign()
        {
            return _unassignCoursesGateway.Unassign();
        }
    }
}