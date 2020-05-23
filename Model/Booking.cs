using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Booking
    {
        public DateTime validity;
        public DateTime date;

        public Booking(DateTime validity, DateTime date)
        {
            this.validity = validity;
            this.date = date;
        }
    }
}
