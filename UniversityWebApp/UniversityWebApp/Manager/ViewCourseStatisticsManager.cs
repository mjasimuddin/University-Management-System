using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class ViewCourseStatisticsManager
    {
        ViewCourseStatisticsGateway _courseStatisticsGateway = new ViewCourseStatisticsGateway();

        public List<ViewCourseStatistics> GetAllStatistics(int id)
        {
            return _courseStatisticsGateway.GetAllStatistics(id);
        }
    }
}