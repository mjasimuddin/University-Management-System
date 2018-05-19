using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class ViewCourseStatisticsController : Controller
    {
        //
        // GET: /ViewCourseStatistics/
        DepartmentManager _departmentManager = new DepartmentManager();
        ViewCourseStatisticsManager _courseStatisticsManager = new ViewCourseStatisticsManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        public JsonResult GetAllStatistics(int id)
        {
            int ids = Convert.ToInt32(id);
            List<ViewCourseStatistics> data = _courseStatisticsManager.GetAllStatistics(ids);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}