using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddErp.Model.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool LockoutEnabled { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public string RocID { get; set; }
        public string RealName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
