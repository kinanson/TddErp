namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseDetails
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        public string PurchaseID { get; set; }

        [Display(Name="項次")]
        [Key]
        [Column(Order = 1)]
        [ReadOnly(true)]
        public byte Seq { get; set; }
      
        [Display(Name="數量")]
        [Required]
        public int Quantity { get; set; }

        [Display(Name="單價")]
        [Required]
        public int Price { get; set; }

        [Display(Name="金額")]
        [Required]
        public int SubTotal { get; set; }

        [Required]
        [MaxLength(10)]
        public string BookID { get; set; }
        public virtual Books Books { get; set; }

        public virtual PurchaseMaster PurchaseMaster { get; set; }
    }
}
