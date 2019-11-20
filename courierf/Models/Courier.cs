namespace courierf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courier")]
    public partial class Courier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Courier_id { get; set; }

        public int? Weight { get; set; }

        [StringLength(25)]
        [Display(Name = "Details")]
        public string Courier_type { get; set; }
    }
}
