using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class StudentRegistrationController : Controller
    {
        //
        // GET: /StudentRegistration/
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentRegistrationManager _studentRegistrationManager = new StudentRegistrationManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentRegistration aStudentRegistration)
        {
            ViewBag.Message = _studentRegistrationManager.Register(aStudentRegistration);
            ViewBag.Data = _studentRegistrationManager.LastStudent();
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
	}
}