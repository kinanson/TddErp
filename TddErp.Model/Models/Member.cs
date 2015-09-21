namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            SalesMaster = new HashSet<SalesMaster>();
        }

        public string Id { get; set; }

        [Display(Name = "加入日期")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime JoinDate { get; set; }

        [Display(Name = "部落格")]
        [MaxLength(30)]
        public string Blog { get; set; }

        [Display(Name = "計算機概論")]
        public bool Hob01 { get; set; }

        [Display(Name = "Office")]
        public bool Hob02 { get; set; }

        [Display(Name = "網頁設計")]
        public bool Hob03 { get; set; }

        [Display(Name = "美工繪圖")]
        public bool Hob04 { get; set; }

        [Display(Name = "影音剪輯")]
        public bool Hob05 { get; set; }

        [Display(Name = "3D動畫")]
        public bool Hob06 { get; set; }

        [Display(Name = "工業與建築")]
        public bool Hob07 { get; set; }

        [Display(Name = "作業系統")]
        public bool Hob08 { get; set; }

        [Display(Name = "資訊管理")]
        public bool Hob09 { get; set; }

        [Display(Name = "電子商務")]
        public bool Hob10 { get; set; }

        [Display(Name = "網路通訊")]
        public bool Hob11 { get; set; }

        [Display(Name = "程式語言")]
        public bool Hob12 { get; set; }

        [Display(Name = "遊戲設計")]
        public bool Hob13 { get; set; }

        [Display(Name = "資料庫")]
        public bool Hob14 { get; set; }

        [Display(Name = "演算法")]
        public bool Hob15 { get; set; }

        [Display(Name = "資料統計與數值分析")]
        public bool Hob16 { get; set; }

        [Display(Name = "嵌入式系統")]
        public bool Hob17 { get; set; }

        [Display(Name = "工具軟體")]
        public bool Hob18 { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SalesMaster> SalesMaster { get; set; }
    }
}