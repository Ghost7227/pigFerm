using pigFerm.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigFerm.database
{
    public partial class room
    {
        public string performanceRoom()
        {
            if(roomType != null)
            {
                return "";
            }
            return roomType?.nameRoomTtpes;
        } 
    }
}
