using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    public class SiteParameter
    {
        [Display(Name = "编号")]
        public int id { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "参数名")]
        public string ParameterName { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "参数类型")]
        public string ParameterType { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
