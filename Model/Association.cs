using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    /// <summary>
    /// 协会信息
    /// </summary>
    public class Association
    {
        [Display(Name = "协会名称")]
        public int id { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "协会名称")]
        public string AssociationName { get; set; }

        [Display(Name = "链接地址")]
        public string AssociationUrl { get; set; }

        [Required(ErrorMessage = "*必选")]
        [Display(Name = "协会类型")]
        public int AssociationType { get; set; }

        [Display(Name = "展示顺序")]
        [RegularExpression(@"\d{1,9}")]
        public int ShowOrder { get; set; }

        [Display(Name = "协会类型")]
        public string AssociationTypeName { get; set; }
    }
}
