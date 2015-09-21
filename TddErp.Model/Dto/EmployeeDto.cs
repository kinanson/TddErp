using System;
using System.ComponentModel.DataAnnotations;

namespace TddErp.Model.Dto
{
    public class EmployeeDto
    {
        [Display(Name = "到職日")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ArriveDate { get; set; }

        [Display(Name = "離職日")]
        [DataType(DataType.Date)]
        public DateTime? ExitDate { get; set; }
    }
}