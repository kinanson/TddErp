namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrawMaster")]
    public partial class DrawMaster
    {
        public DrawMaster()
        {
            DrawDetails = new HashSet<DrawDetails>();
        }

        [Display(Name="出庫單號碼")]
        [Key]
        [MaxLength(10)]
        public string DrawID { get; set; }

        [Display(Name="出庫日期")]
        [DataType(DataType.Date)]
        public DateTime DrawDate { get; set; }

        public virtual ICollection<DrawDetails> DrawDetails { get; set; }
    }
}
