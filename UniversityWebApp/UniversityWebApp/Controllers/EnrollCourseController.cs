using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        //
        // GET: /EnrollCourse/
        DepartmentManager _departmentManager = new DepartmentManager();
        SaveCourseManager _courseManager = new SaveCourseManager();
        StudentRegistrationManager _studentRegistrationManager = new StudentRegistrationManager();
        EnrollCourseManager _enrollCourseManager = new EnrollCourseManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Index(EnrollCourse _enrollCourse)
        {
            ViewBag.Message = _enrollCourseManager.SaveEnroll(_enrollCourse);
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        public JsonResult GateCourseList(int DeptId)
        {
            int id = Convert.ToInt32(DeptId);
            List<SaveCourse> data = _courseManager.GetAllCourses(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRegStudentList(int DeptId)
        {
            int id = Convert.ToInt32(DeptId);
            List<StudentRegistration> data = _studentRegistrationManager.GetRegStudentList(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudentDetails(int StudentId)
        {
            int id = Convert.ToInt32(StudentId);
            List<StudentRegistration> data = _studentRegistrationManager.GetStudentDetails(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}