namespace courierf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Branch")]
    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [StringLength(250)]
        public string Branch_code { get; set; }

        public int? Branch_pin { get; set; }

        [StringLength(250)]
        public string Branch_address { get; set; }

        [StringLength(250)]
        public string Branch_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
