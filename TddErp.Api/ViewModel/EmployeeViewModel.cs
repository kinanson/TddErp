using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TddErp.Model.Dto;

namespace TddErp.Api.ViewModel
{
    public class EmployeeViewModel
    {
        public UserDto User { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}