using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityWebApp.Manager;

namespace UniversityWebApp.Controllers
{
    public class UnallocateRoomsController : Controller
    {
        //
        // GET: /UnallocateRooms/
        UnallocateRoomsManager _unallocateRoomsManager = new UnallocateRoomsManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Unallocate()
        {

            ViewBag.Message = _unallocateRoomsManager.Unallocate();
            return View();
        }
	}
}