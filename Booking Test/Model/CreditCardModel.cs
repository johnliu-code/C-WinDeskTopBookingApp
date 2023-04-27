using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class CreditCardModel
    {
        public int Id { get; set; }
        public string Holder_name { get; set; }
        public string Card_number { get; set; }
        public DateTime Expire_date { get; set;}
        public int CVV { get; set; }
        public string Card_type { get; set; }
    }
}
