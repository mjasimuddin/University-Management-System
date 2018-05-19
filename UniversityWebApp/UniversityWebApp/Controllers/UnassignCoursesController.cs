using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;

namespace UniversityWebApp.Controllers
{
    public class UnassignCoursesController : Controller
    {
        //
        // GET: /UnassignCourses/
        UnassignCoursesManager _unassignCoursesManager = new UnassignCoursesManager();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Unassign()
        {

            ViewBag.Message = _unassignCoursesManager.Unassign();
            return View();
        }
	}
}