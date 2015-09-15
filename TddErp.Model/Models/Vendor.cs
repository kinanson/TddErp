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

        [Display(Name="�t�ӽs��")]
        [MaxLength(5)]
        [ReadOnly(true)]
        public string VendorID { get; set; }

        [Display(Name = "�t�ӦW��")]
        [Required]
        [MaxLength(40)]
        public string VendorName { get; set; }

        [Display(Name = "�q��")]
        [Required]
        [MaxLength(15)]
        public string Tel { get; set; }

        [Display(Name = "�ǯu")]
        [MaxLength(15)]
        public string Fax { get; set; }

        [Display(Name = "�Τ@�s��")]
        [MaxLength(8)]
        public string EarNo { get; set; }

        [Display(Name = "�a�}")]
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "���}")]
        [MaxLength(30)]
        public string Web { get; set; }

        [Display(Name = "�p���H")]
        [Required]
        [MaxLength(10)]
        public string Contact { get; set; }

        [Display(Name = "��ʹq��")]
        [MaxLength(10)]
        [Required]
        public string MobilePhone { get; set; }

        [Display(Name = "Mail")]
        [MaxLength(30)]
        public string EMail { get; set; }

        public virtual ICollection<PurchaseMaster> PurchaseMaster { get; set; }
    }
}
