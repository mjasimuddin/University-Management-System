using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class CourseAssignTeacherController : Controller
    {
        //
        // GET: /CourseAssignTeacher/
        DepartmentManager _departmentManager = new DepartmentManager();
        SaveTeacherManager _saveTeacherManager = new SaveTeacherManager();
        SaveCourseManager _courseManager = new SaveCourseManager();
        CourseAssignTeacherManager _courseAssignTeacherManager = new CourseAssignTeacherManager();
        public ActionResult Index()
        {
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Index(CourseAssignTeacher assignTeacher)
        {
            ViewBag.Message = _courseAssignTeacherManager.AssignCourseToTeacher(assignTeacher);
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }

        public JsonResult GateTeacherList(int DeptId)
        {
            int id = Convert.ToInt32(DeptId);
            List<SaveTeacher> data = _saveTeacherManager.GetAllTeachers(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GateCourseList(int DeptId)
        {
            int id = Convert.ToInt32(DeptId);
            List<SaveCourse> data = _courseManager.GetAllCourses(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GateTeacherdetail(int TeacherId)
        {
            int id = Convert.ToInt32(TeacherId);
            List<SaveTeacher> data = _saveTeacherManager.GetAllteacherDetais(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GateCourseDetail(int CourseId)
        {
            int id = Convert.ToInt32(CourseId);
            List<SaveCourse> data = _courseManager.GateCourseDetail(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
	}
}