using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class SaveStudentResultController : Controller
    {
        //
        // GET: /SaveStudentResult/
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentRegistrationManager _studentRegistrationManager = new StudentRegistrationManager();
        GradeManager _gradeManager = new GradeManager();
        SaveStudentResultManager _saveStudentResultManager = new SaveStudentResultManager();
        
        public ActionResult Index()
        {
            ViewBag.Grades = _gradeManager.GetAllGrades();
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Index(SaveStubentResult _saveStubentResult)
        {
            ViewBag.Message = _saveStudentResultManager.SaveResult(_saveStubentResult);
            ViewBag.Grades = _gradeManager.GetAllGrades();
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
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
        public JsonResult GateCourseList(int StudentRegId)
        {
            int id = Convert.ToInt32(StudentRegId);
            List<EnrolledCourseList> data = _saveStudentResultManager.GateCourseList(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
	}
}