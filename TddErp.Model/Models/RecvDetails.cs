namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RecvDetails
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        public string RecvID { get; set; }

        [Display(Name="項次")]
        [Key]
        [Column(Order = 1)]
        public byte Seq { get; set; }

        [Display(Name="數量")]
        [Required]
        public int? Quantity { get; set; }

        [MaxLength(10)]
        public string BookID { get; set; }
        public virtual Books Books { get; set; }

        public virtual RecvMaster RecvMaster { get; set; }
    }
}
