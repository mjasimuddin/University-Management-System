using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class StartTimeManager
    {
        StartTimeGateway _startTimeGateway = new StartTimeGateway();
        public List<StartTime> GetAllTimes()
        {
            return _startTimeGateway.GetAllTimes();
        } 
    }
}