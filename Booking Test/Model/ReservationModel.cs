using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class ReservationModel
    {
        public Guid ReservationId { get; set; }
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        public int Number { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        public int RoomNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
