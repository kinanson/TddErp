namespace TddErp.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoice")]
    public partial class Invoice
    {
        [Display(Name = "�o���~��")]
        [MaxLength(4)]
        public string InvoiceYear { get; set; }

        [Display(Name = "�o�����")]
        [MaxLength(2)]
        public string InvoiceMonth { get; set; }

        [Display(Name = "�o�����X")]
        [Key]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "�o�����")]
        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        [Display(Name = "�Τ@�s��")]
        [MaxLength(8)]
        public string EarNo { get; set; }

        [Display(Name = "�o���p��")]
        [MaxLength(1)]
        public string InvoiceType { get; set; }

        [Display(Name = "���|�P����B")]
        public int? GrandTotal { get; set; }

        [Display(Name = "��~�|")]
        public int? ValueAddTax { get; set; }

        [Display(Name = "�ϥΪ��A")]
        [MaxLength(1)]
        public string IsUsed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}