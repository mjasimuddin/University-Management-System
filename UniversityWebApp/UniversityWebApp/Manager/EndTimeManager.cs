using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class EndTimeManager
    {
        EndTimeGateway _endTimeGateway = new EndTimeGateway();
        public List<EndTime> GetAllTimes()
        {
            return _endTimeGateway.GetAllTimes();
        }
    }
}