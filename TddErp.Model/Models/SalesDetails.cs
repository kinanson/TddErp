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

        [Display(Name="����")]
        [Key]
        [Column(Order = 1)]
        public byte Seq { get; set; }

        [Display(Name="�ƶq")]
        [Required]
        public int Quantity { get; set; }

        [Display(Name = "�t�|���")]
        [Required]
        public int? Price { get; set; }

        [Display(Name = "�t�|�馩���B")]
        [Required]
        public byte? Discount { get; set; }

        [Display(Name = "�t�|�P����B")]
        [Required]
        public int? SubTotal { get; set; }

        [Display(Name = "���|�P����B")]
        [Required]
        public int? SalesAmount { get; set; }

        [MaxLength(10)]
        public string BookID { get; set; }
        public virtual Books Books { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
    }
}
