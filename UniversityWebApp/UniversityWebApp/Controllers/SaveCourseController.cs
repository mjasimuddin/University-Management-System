using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class SaveCourseController : Controller
    {
        //
        // GET: /SaveCourse/
        DepartmentManager _departmentManager = new DepartmentManager();
        SemesterManager _semesterManager = new SemesterManager();
        SaveCourseManager _saveCourseManager = new SaveCourseManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            ViewBag.Semesters = _semesterManager.GetAllSemesters();
            return View();
        }
        [HttpPost]
        public ActionResult Index(SaveCourse aCourse)
        {
            ViewBag.Message = _saveCourseManager.Save(aCourse);
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            ViewBag.Semesters = _semesterManager.GetAllSemesters();
            return View();
        }
	}
}