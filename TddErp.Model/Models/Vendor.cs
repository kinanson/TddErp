namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendor")]
    public partial class Vendor
    {
        public Vendor()
        {
            PurchaseMaster = new HashSet<PurchaseMaster>();
        }

        [Display(Name="廠商編號")]
        [MaxLength(5)]
        [ReadOnly(true)]
        public string VendorID { get; set; }

        [Display(Name = "廠商名稱")]
        [Required]
        [MaxLength(40)]
        public string VendorName { get; set; }

        [Display(Name = "電話")]
        [Required]
        [MaxLength(15)]
        public string Tel { get; set; }

        [Display(Name = "傳真")]
        [MaxLength(15)]
        public string Fax { get; set; }

        [Display(Name = "統一編號")]
        [MaxLength(8)]
        public string EarNo { get; set; }

        [Display(Name = "地址")]
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "網址")]
        [MaxLength(30)]
        public string Web { get; set; }

        [Display(Name = "聯絡人")]
        [Required]
        [MaxLength(10)]
        public string Contact { get; set; }

        [Display(Name = "行動電話")]
        [MaxLength(10)]
        [Required]
        public string MobilePhone { get; set; }

        [Display(Name = "Mail")]
        [MaxLength(30)]
        public string EMail { get; set; }

        public virtual ICollection<PurchaseMaster> PurchaseMaster { get; set; }
    }
}
