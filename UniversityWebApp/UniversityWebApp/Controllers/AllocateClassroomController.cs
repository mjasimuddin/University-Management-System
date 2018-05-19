using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;
using UniversityWebApp.Models;

namespace UniversityWebApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
        //
        // GET: /AllocateClassroom/
        DepartmentManager _departmentManager = new DepartmentManager();
        DaysManager _daysManager = new DaysManager();
        RoomManager _roomManager = new RoomManager();
        AllocateClassRoomManager _allocateClassRoomManager = new AllocateClassRoomManager();
        StartTimeManager _startTimeManager = new StartTimeManager();
        EndTimeManager _endTimeManager = new EndTimeManager();
        public ActionResult Index()
        {
            ViewBag.StartTime = _startTimeManager.GetAllTimes();
            ViewBag.EndTime = _endTimeManager.GetAllTimes();
            ViewBag.Rooms = _roomManager.GetAllRooms();
            ViewBag.Days = _daysManager.GetAllDays();
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Index(AllocateClassroom _allocateClassroom)
        {
            ViewBag.Message = _allocateClassRoomManager.Allocate(_allocateClassroom);
            ViewBag.StartTime = _startTimeManager.GetAllTimes();
            ViewBag.EndTime = _endTimeManager.GetAllTimes();
            ViewBag.Rooms = _roomManager.GetAllRooms();
            ViewBag.Days = _daysManager.GetAllDays();
            ViewBag.Departments = _departmentManager.GetAllDepartment();
            return View();
        }
	}
}