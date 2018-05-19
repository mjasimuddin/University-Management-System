using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class RoomManager
    {
        RoomGateway _roomGateway = new RoomGateway();
        public List<Rooms> GetAllRooms()
        {
            return _roomGateway.GetAllRooms();
        }
    }
}