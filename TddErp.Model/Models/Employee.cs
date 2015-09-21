namespace TddErp.Model.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            SalesMaster = new HashSet<SalesMaster>();
        }

        public string Id { get; set; }

        [Display(Name = "到職日期")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ArriveDate { get; set; }

        [Display(Name = "離職日")]
        [DataType(DataType.Date)]
        public DateTime? ExitDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SalesMaster> SalesMaster { get; set; }
    }
}