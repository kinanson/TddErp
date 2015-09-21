namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        public Books()
        {
            DrawDetails = new HashSet<DrawDetails>();
            PurchaseDetails = new HashSet<PurchaseDetails>();
            RecvDetails = new HashSet<RecvDetails>();
            SalesDetails = new HashSet<SalesDetails>();
        }
        
        [Display(Name="書號")]
        [Key]
        [MaxLength(10)]
        public string BookID { get; set; }

        [Display(Name="書名")]
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Display(Name="作者")]
        [MaxLength(30)]
        [Required]
        public string Author { get; set; }

        [Display(Name="定價")]
        [Required]
        public int Price { get; set; }

        [Display(Name="倉庫庫存量")]
        [Required]
        public int WarehouseStock { get; set; }

        [Display(Name = "門市庫存量")]
        [Required]
        public int ShopStock { get; set; }

        [Required]
        [MaxLength(2)]
        public string BookGroupID { get; set; }
        public virtual BookGroup BookGroup { get; set; }

        [Required]
        [MaxLength(3)]
        public string BookTypeID { get; set; }
        public virtual BookType BookType { get; set; }

        [Required]
        [MaxLength(5)]
        public string PublishID { get; set; }
        public virtual Publish Publish { get; set; }
        public virtual ICollection<DrawDetails> DrawDetails { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<RecvDetails> RecvDetails { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
