namespace TddErp.Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DrawDetails
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        public string DrawID { get; set; }

        [Display(Name = "項次")]
        [Key]
        [Column(Order = 1)]
        public byte Seq { get; set; }

        [Display(Name = "數量")]
        public int? Quantity { get; set; }

        [MaxLength(10)]
        public string BookID { get; set; }

        public virtual Books Books { get; set; }

        public virtual DrawMaster DrawMaster { get; set; }
    }
}