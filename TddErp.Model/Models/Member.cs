namespace TddErp.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            SalesMaster = new HashSet<SalesMaster>();
        }

        public string Id { get; set; }

        [Display(Name = "�[�J���")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime JoinDate { get; set; }

        [Display(Name = "������")]
        [MaxLength(30)]
        public string Blog { get; set; }

        [Display(Name = "�p�������")]
        public bool Hob01 { get; set; }

        [Display(Name = "Office")]
        public bool Hob02 { get; set; }

        [Display(Name = "�����]�p")]
        public bool Hob03 { get; set; }

        [Display(Name = "���uø��")]
        public bool Hob04 { get; set; }

        [Display(Name = "�v���ſ�")]
        public bool Hob05 { get; set; }

        [Display(Name = "3D�ʵe")]
        public bool Hob06 { get; set; }

        [Display(Name = "�u�~�P�ؿv")]
        public bool Hob07 { get; set; }

        [Display(Name = "�@�~�t��")]
        public bool Hob08 { get; set; }

        [Display(Name = "��T�޲z")]
        public bool Hob09 { get; set; }

        [Display(Name = "�q�l�Ӱ�")]
        public bool Hob10 { get; set; }

        [Display(Name = "�����q�T")]
        public bool Hob11 { get; set; }

        [Display(Name = "�{���y��")]
        public bool Hob12 { get; set; }

        [Display(Name = "�C���]�p")]
        public bool Hob13 { get; set; }

        [Display(Name = "��Ʈw")]
        public bool Hob14 { get; set; }

        [Display(Name = "�t��k")]
        public bool Hob15 { get; set; }

        [Display(Name = "��Ʋέp�P�ƭȤ��R")]
        public bool Hob16 { get; set; }

        [Display(Name = "�O�J���t��")]
        public bool Hob17 { get; set; }

        [Display(Name = "�u��n��")]
        public bool Hob18 { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SalesMaster> SalesMaster { get; set; }
    }
}