namespace cake_assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cake
    {
        public int CakeID { get; set; }

        [Required]
        [StringLength(100)]
        public string CakeName { get; set; }

        public virtual CakeDesc CakeDesc { get; set; }
    }
}
