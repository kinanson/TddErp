namespace TddErp.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BookType")]
    public partial class BookType
    {
        public BookType()
        {
            Books = new HashSet<Books>();
        }

        [MaxLength(3)]
        [ReadOnly(true)]
        [Display(Name = "書藉小類編號")]
        public string BookTypeID { get; set; }

        [MaxLength(20)]
        [Display(Name = "書藉小類名稱")]
        [Required]
        public string BookTypeName { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}