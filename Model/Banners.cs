using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
    /// <summary>
    /// Banners:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Banners
    {
        [Display(Name = "编号")]
        public int id { get; set; }

        [Required(ErrorMessage = "必须上传图片")]
        [Display(Name = "图片")]
        public string ImagePath { get; set; }

        [Display(Name = "alt文字")]
        public string ImageAlt { get; set; }

        [Display(Name = "图片链接")]
        public string ImageUrl { get; set; }

        [Display(Name = "图片位置")]
        public string Loacation { get; set; }

        [Display(Name = "添加时间")]
        public DateTime CreateDate { get; set; }
    }
}

