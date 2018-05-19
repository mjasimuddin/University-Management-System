using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class SaveTeacherController : Controller
    {
        //
        // GET: /SaveTeacher/
        DesignationTeacherManager _designationTeacherManager = new DesignationTeacherManager();
        DepartmentManager _departmentManager = new DepartmentManager();
        SaveTeacherManager _saveTeacherManager = new SaveTeacherManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            ViewBag.Designations = _designationTeacherManager.GetAllDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult Index(SaveTeacher aTeacher)
        {
            ViewBag.Message = _saveTeacherManager.Save(aTeacher);
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            ViewBag.Designations = _designationTeacherManager.GetAllDesignation();

            return View();
        }
	}
}