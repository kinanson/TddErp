namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseMaster")]
    public partial class PurchaseMaster
    {
        public PurchaseMaster()
        {
            PurchaseDetails = new HashSet<PurchaseDetails>();
        }

        [Display(Name="進貨編號")]
        [Key]
        [MaxLength(10)]
        [ReadOnly(true)]
        public string PurchaseID { get; set; }

         [Display(Name = "進貨日期")]
        [Required]
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name="發票號碼")]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "小計金額")]
        public int GrandTotal { get; set; }

        [Display(Name = "營業稅")]
        public int ValueAddTax { get; set; }

        [Display(Name = "總計金額")]
        public int Amount { get; set; }

        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }

        [Required]
        [MaxLength(5)]
        public string VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
