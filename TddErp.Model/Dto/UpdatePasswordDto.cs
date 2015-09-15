using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddErp.Model.Dto
{
    public class UpdatePasswordDto
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "舊密碼最多{1}碼")]
        [MinLength(6, ErrorMessage = "舊密碼最少{1}碼")]
        [DataType(DataType.Password)]
        [Display(Name = "舊密碼")]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "新密碼最多{1}碼")]
        [MinLength(6, ErrorMessage = "新密碼最少{1}碼")]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "確認密碼必須要跟新密碼相符")]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        public string ConfirmPassword { get; set; }
    }
}
