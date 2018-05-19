using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        DepartmentManager _departmentManager = new DepartmentManager();
        public ActionResult Index()
        {
            List<Department> departments = _departmentManager.GetAllDepartment();
            return View(departments);
        }
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {

            ViewBag.Message = _departmentManager.Save(aDepartment);
            return View();
        }
	}
}