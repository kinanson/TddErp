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

        [Display(Name="�i�f�s��")]
        [Key]
        [MaxLength(10)]
        [ReadOnly(true)]
        public string PurchaseID { get; set; }

         [Display(Name = "�i�f���")]
        [Required]
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name="�o�����X")]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "�p�p���B")]
        public int GrandTotal { get; set; }

        [Display(Name = "��~�|")]
        public int ValueAddTax { get; set; }

        [Display(Name = "�`�p���B")]
        public int Amount { get; set; }

        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }

        [Required]
        [MaxLength(5)]
        public string VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
