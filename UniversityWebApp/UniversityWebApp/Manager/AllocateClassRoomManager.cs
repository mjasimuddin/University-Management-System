using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;
using UniversityWebApp.Models;

namespace UniversityWebApp.Manager
{
    public class AllocateClassRoomManager
    {
        AllocateClassRoomGateway _allocateClassRoomGateway = new AllocateClassRoomGateway();

        public string Allocate(AllocateClassroom _allocateClassroom)
        {
            if (_allocateClassRoomGateway.Check(_allocateClassroom))
            {
                return "Room is already allocated";
            }
            return _allocateClassRoomGateway.Allocate(_allocateClassroom);
        }
    }
}