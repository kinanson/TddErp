namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesMaster")]
    public partial class SalesMaster
    {
        public SalesMaster()
        {
            SalesDetails = new HashSet<SalesDetails>();
        }

        [Display(Name="�P�⸹�X")]
        [Key]
        [MaxLength(10)]
        public string SalesID { get; set; }

        [Display(Name = "�P����")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? SalesDate { get; set; }

        [Display(Name = "�P��ɶ�")]
        [Required]
        public TimeSpan? SalesTime { get; set; }

        [Display(Name = "�o�����X")]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "�P����B")]
        public int? GrandTotal { get; set; }

        [Display(Name = "��~�|")]
        public int? ValueAddTax { get; set; }

        [Display(Name = "�`�p���B")]
        public int? Amount { get; set; }

        [Display(Name = "�Ȥ�s�N�X")]
        [Required]
        [MaxLength(1)]
        public string CustomerGroup { get; set; }
      
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
