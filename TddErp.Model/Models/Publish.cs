namespace TddErp.Model.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publish")]
    public partial class Publish
    {
        public Publish()
        {
            Books = new HashSet<Books>();
        }

        [Display(Name = "�X�����s��")]
        [MaxLength(5)]
        [ReadOnly(true)]
        public string PublishID { get; set; }

        [Display(Name = "�X�����W��")]
        [MaxLength(20)]
        [Required]
        public string PublishName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Books> Books { get; set; }
    }
}
