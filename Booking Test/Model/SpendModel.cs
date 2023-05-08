using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class SpendModel
    {
        public int Id { get; set; }
        public Guid Reservation_id { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
