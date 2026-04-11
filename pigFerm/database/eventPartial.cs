using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigFerm.database
{
    public partial class @event
    {
        public string typeAndDateEvent
        {
            get
            {
                string str = EventType.nameEvent + " " + dateTime.ToString();
                return str;
            }
        }
    }
}
