using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pigFerm.database
{
    public partial class product
    {
        public string quantityUnit
        {
            get
            {
                string str = quantity.ToString() + " " + productType.unit;
                return str;
            }
        }

        public string costUnit
        {
            get
            {
                string str = productType.cost.ToString() + " руб. за " + productType.unit;
                return str;
            }
        }

        public string eventNameAndDate
        {
            get
            {
                string str = @event.EventType.nameEvent + " " + @event.dateTime.ToString(); ;
                return str;
            }
        }

        public int queryQuantity { get; set; }

        public SolidColorBrush brush
        {
            get
            {
                if (expirationDate <= DateTime.Now)
                {
                    SolidColorBrush br = new SolidColorBrush(Color.FromArgb(100, 200, 0, 0));
                    return br;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
