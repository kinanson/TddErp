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

        [Display(Name="銷售號碼")]
        [Key]
        [MaxLength(10)]
        public string SalesID { get; set; }

        [Display(Name = "銷售日期")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? SalesDate { get; set; }

        [Display(Name = "銷售時間")]
        [Required]
        public TimeSpan? SalesTime { get; set; }

        [Display(Name = "發票號碼")]
        [MaxLength(10)]
        public string InvoiceNo { get; set; }

        [Display(Name = "銷售金額")]
        public int? GrandTotal { get; set; }

        [Display(Name = "營業稅")]
        public int? ValueAddTax { get; set; }

        [Display(Name = "總計金額")]
        public int? Amount { get; set; }

        [Display(Name = "客戶群代碼")]
        [Required]
        [MaxLength(1)]
        public string CustomerGroup { get; set; }
      
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }

        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
