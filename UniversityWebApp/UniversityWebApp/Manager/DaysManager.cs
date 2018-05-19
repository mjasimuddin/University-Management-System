using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class DaysManager
    {
        DaysGateway _daysGateway = new DaysGateway();
        public List<Days> GetAllDays()
        {
            return _daysGateway.GetAllDays();
        }
    }
}