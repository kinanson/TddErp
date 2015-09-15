using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
