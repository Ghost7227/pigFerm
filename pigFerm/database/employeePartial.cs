using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigFerm.database
{
    partial class employee
    {
        public string fio
        {
            get
            {
                string str = firstName;
                if(!string.IsNullOrEmpty(midleName)) str = str + " " + midleName;
                str += " " + lastName;
                return str;
            }
        }

        public string descriptionEventEmployee{ get; set; }
        public string emailCor
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(email)) return "Не указана";
                else return email;
            }
        }
    }
}
