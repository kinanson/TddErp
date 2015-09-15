namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalesDetails
    {
        
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        public string SalesID { get; set; }

        [Display(Name="¶µ¦¸")]
        [Key]
        [Column(Order = 1)]
        public byte Seq { get; set; }

        [Display(Name="¼Æ¶q")]
        [Required]
        public int Quantity { get; set; }

        [Display(Name = "§tµ|°â»ù")]
        [Required]
        public int? Price { get; set; }

        [Display(Name = "§tµ|§é¦©ª÷ÃB")]
        [Required]
        public byte? Discount { get; set; }

        [Display(Name = "§tµ|¾P°âª÷ÃB")]
        [Required]
        public int? SubTotal { get; set; }

        [Display(Name = "¥¼µ|¾P°âª÷ÃB")]
        [Required]
        public int? SalesAmount { get; set; }

        [MaxLength(10)]
        public string BookID { get; set; }
        public virtual Books Books { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
    }
}
