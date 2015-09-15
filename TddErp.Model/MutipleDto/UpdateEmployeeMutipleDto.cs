using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddErp.Model.Dto;

namespace TddErp.Model.MutipleDto
{
    public class UpdateEmployeeMutipleDto
    {
        public UserDto User { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
