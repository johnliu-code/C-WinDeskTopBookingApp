using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Test.Model
{
    public class PeriodModel
    {
        public int Id { get; set; }
        public int Season_id { get; set; }
        public DateTime Start_date{ get; set; }
        public DateTime End_date { get; set; }
        public string Week_day { get; set; }
    }
}
