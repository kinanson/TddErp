using System.ComponentModel.DataAnnotations;

namespace TddErp.Model.InputDto
{
    public class CreateRoleBindingModel
    {
        [Required]
        [MaxLength(256, ErrorMessage = "最多{1}碼")]
        [MinLength(2, ErrorMessage = "最少{1}碼")]
        [Display(Name = "角色名稱")]
        public string Name { get; set; }
    }
}