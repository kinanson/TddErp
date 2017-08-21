namespace TddErp.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BookGroup")]
    public partial class BookGroup
    {
        public BookGroup()
        {
            Books = new HashSet<Books>();
        }

        [Display(Name = "書藉大類編號")]
        [MaxLength(2)]
        [ReadOnly(true)]
        public string BookGroupID { get; set; }

        [Display(Name = "書藉大類名稱")]
        [MaxLength(20)]
        [Required]
        public string BookGroupName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}