using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class ViewResultController : Controller
    {
        //
        // GET: /ViewResult/
        DepartmentManager _departmentManager = new DepartmentManager();
        StudentRegistrationManager _studentRegistrationManager = new StudentRegistrationManager();
        SaveStudentResultManager _saveStudentResultManager = new SaveStudentResultManager();
        ViewStudentResultManager _studentResultManager = new ViewStudentResultManager();
        public ActionResult Index()
        {
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
        public JsonResult GetAllResults(int id)
        {
            int ids = Convert.ToInt32(id);
            List<ViewStudentResult> data = _studentResultManager.GetAllResults(ids);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}