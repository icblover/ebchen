using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    /// <summary>
    /// 栏目导航
    /// </summary>
    public class ColumnNavigation
    {
        [Display(Name = "编号")]
        public int id { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "栏目名称")]
        public string ColumnName { get; set; }

        [Display(Name = "链接地址")]
        public string ColumnUrl { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
