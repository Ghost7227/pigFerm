using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigFerm.database
{
    public partial class AnimalGroup
    {
        public string view
        {
            get
            {
                return id.ToString() + groupType.nameGroup;
            }
        }
    }
}
