namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RecvMaster")]
    public partial class RecvMaster
    {
        public RecvMaster()
        {
            RecvDetails = new HashSet<RecvDetails>();
        }

        [Display(Name = "�J�w�渹�X")]
        [Key]
        [MaxLength(10)]
        public string RecvID { get; set; }

        [Display(Name = "�J�w����")]
        [DataType(DataType.Date)]
        public DateTime RecvDate { get; set; }

        public virtual ICollection<RecvDetails> RecvDetails { get; set; }
    }
}