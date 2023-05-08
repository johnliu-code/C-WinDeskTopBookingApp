using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class RateModel
    {
        public int ID { get; set; }
        public int Season_id { get; set; }
        public int Room_id { get; set; }
        public decimal Price { get; set; }
    }
}
