using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TddErp.Model.Dto;

namespace TddErp.Api.ViewModel
{
    public class MemberViewModel
    {
        public UserDto User { get; set; }
        public MemberDto Member { get; set; }
    }
}