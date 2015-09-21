using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddErp.Model.InputDto
{
    public class CreateMemberDto
    {  
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "帳號")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "角色至少要選一個")]
        [Display(Name = "Roles")]
        public string[] Roles { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "密碼最多{1}碼")]
        [MinLength(6, ErrorMessage = "密碼最少{1}碼")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "確認密碼必須要與密碼相符")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "姓名")]
        [MaxLength(12)]
        [Required]
        public string RealName { get; set; }

        [Display(Name = "性別")]
        [MaxLength(1)]
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

        public string PhoneNumber { get; set; }

        [Display(Name = "會員編號")]
        [MaxLength(8)]
        public string MemberID { get; set; }

        [Display(Name = "加入日期")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime JoinDate { get; set; }

        [Display(Name = "部落格")]
        [MaxLength(30)]
        public string Blog { get; set; }

        [Display(Name = "計算機概論")]
        public bool Hob01 { get; set; }

        [Display(Name = "Office")]
        public bool Hob02 { get; set; }

        [Display(Name = "網頁設計")]
        public bool Hob03 { get; set; }

        [Display(Name = "美工繪圖")]
        public bool Hob04 { get; set; }

        [Display(Name = "影音剪輯")]
        public bool Hob05 { get; set; }

        [Display(Name = "3D動畫")]
        public bool Hob06 { get; set; }

        [Display(Name = "工業與建築")]
        public bool Hob07 { get; set; }

        [Display(Name = "作業系統")]
        public bool Hob08 { get; set; }

        [Display(Name = "資訊管理")]
        public bool Hob09 { get; set; }

        [Display(Name = "電子商務")]
        public bool Hob10 { get; set; }

        [Display(Name = "網路通訊")]
        public bool Hob11 { get; set; }

        [Display(Name = "程式語言")]
        public bool Hob12 { get; set; }

        [Display(Name = "遊戲設計")]
        public bool Hob13 { get; set; }

        [Display(Name = "資料庫")]
        public bool Hob14 { get; set; }

        [Display(Name = "演算法")]
        public bool Hob15 { get; set; }

        [Display(Name = "資料統計與數值分析")]
        public bool Hob16 { get; set; }

        [Display(Name = "嵌入式系統")]
        public bool Hob17 { get; set; }

        [Display(Name = "工具軟體")]
        public bool Hob18 { get; set; }
    }
}
