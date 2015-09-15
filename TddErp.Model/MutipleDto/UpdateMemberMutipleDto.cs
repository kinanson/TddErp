using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddErp.Model.Dto;

namespace TddErp.Model.MutipleDto
{
    public class UpdateMemberMutipleDto
    {
        public UserDto User { get; set; }
        public MemberDto Member { get; set; }
    }
}
