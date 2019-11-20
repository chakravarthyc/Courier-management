namespace courierf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        [StringLength(250)]
        public string From_add { get; set; }

        public long? Amount { get; set; }

        [StringLength(250)]
        public string Destination { get; set; }

        [StringLength(250)]
        public string Branch_code { get; set; }

        [StringLength(250)]
        public string Customer_id { get; set; }

        public long? Distance { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
