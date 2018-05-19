using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityWebApp.Gateway;

namespace UniversityWebApp.Manager
{
    public class UnallocateRoomsManager
    {
        UnallocateRoomsGateway _unallocateRoomsGateway = new UnallocateRoomsGateway();
        public string Unallocate()
        {
            return _unallocateRoomsGateway.Unallocate();
        }
    }
}