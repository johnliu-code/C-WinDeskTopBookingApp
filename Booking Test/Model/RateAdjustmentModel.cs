using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Booking_Test.Model
{
    public class RateAdjustmentModel
    {
        public int Id { get; set; }
        public string Adjust_type { get; set; }
        public decimal Adjust_value { get; set; }
    }
}
