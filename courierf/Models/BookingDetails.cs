using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace courierf.Models
{
    public class BookingDetails
    {
        public Booking booking { get; set; }
        public Courier courier { get; set; }
    }
}