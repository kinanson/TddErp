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

        [Display(Name="�X�w�渹�X")]
        [Key]
        [MaxLength(10)]
        public string DrawID { get; set; }

        [Display(Name="�X�w���")]
        [DataType(DataType.Date)]
        public DateTime DrawDate { get; set; }

        public virtual ICollection<DrawDetails> DrawDetails { get; set; }
    }
}
