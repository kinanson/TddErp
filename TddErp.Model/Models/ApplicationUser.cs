using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TddErp.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "姓名")]
        [MaxLength(12)]
        [Required]
        public string RealName { get; set; }

        [Display(Name = "性別")]
        [MaxLength(2)]
        [Required]
        public string Sex { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "身份證號碼")]
        [MaxLength(10)]
        public string RocID { get; set; }

        [Display(Name = "地址")]
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }

        public virtual Member Member { get; set; }
        public virtual Employee Employee { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}