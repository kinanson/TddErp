namespace TddErp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoice")]
    public partial class Invoice
    {
        [Display(Name = "祇布")]
        [MaxLength(4)]
        public string InvoiceYear { get; set; }

        [Display(Name = "祇布る")]
        [MaxLength(2)]
        public string InvoiceMonth { get; set; }

        [Display(Name = "祇布腹絏")]
        [Key]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "祇布ら戳")]
        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        [Display(Name = "参絪腹")]
        [MaxLength(8)]
        public string EarNo { get; set; }

        [Display(Name = "祇布羛Α")]
        [MaxLength(1)]
        public string InvoiceType { get; set; }

        [Display(Name = "ゼ祙綪扳肂")]
        public int? GrandTotal { get; set; }

        [Display(Name = "犁穨祙")]
        public int? ValueAddTax { get; set; }

        [Display(Name = "ㄏノ篈")]
        [MaxLength(1)]
        public string IsUsed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}