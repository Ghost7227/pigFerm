using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigFerm.database
{
    public partial class counterparty
    {
        public string regular
        {
            get
            {
                if (isRegular) return "Постоянный";
                else return "Непостоянный";
            }
        }
    }
}
