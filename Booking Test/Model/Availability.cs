using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class Availability
    {
        public int ID { get; set; }
        public string RoomNumber_id { get;}
        public Guid Reservation_id { get; }
        public DateTime Date { get; set; }
        public string AvailabilitySate { get; set; }
    }
}
