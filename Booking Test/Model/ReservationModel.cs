using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        public int Room_id { get; set; }
        public int Customer_id { get; set; }
        public int Num_adults { get; set; }
        public int Num_children { get; set; }
        public string Occupant { get; set; }
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
        public string Vehicle { get; set; }
        public string Agency { get; set; }
        public string Title { get; set; }
        public string Animals { get; set; }
        public string Time { get; set; }

    }
}
