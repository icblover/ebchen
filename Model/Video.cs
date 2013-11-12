using System;
using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    /// <summary>
    /// 视频
    /// </summary>
    public class Video
    {
        [Display(Name = "编号")]
        public int id { get; set; }

        [Required(ErrorMessage = "*必选")]
        [Display(Name = "所属分类")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "简介")]
        public string Introduce { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "关键字")]
        public string Keyword { get; set; }

        [Display(Name = "记者")]
        public string Reporter { get; set; }

        [Display(Name = "内容")]
        public string Context { get; set; }

        [Display(Name = "视频来源")]
        public string VideoFrom { get; set; }

        [Display(Name = "视频截图")]
        public string VideoImage { get; set; }

        [Display(Name = "视频文件")]
        public string VideoPath { get; set; }

        [Display(Name = "编辑")]
        public int Editor { get; set; }

        [Display(Name = "添加日期")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "二审")]
        public int? FirstAudit { get; set; }

        [Display(Name = "未通过原因")]
        public string FirstAuditReason { get; set; }

        [Display(Name = "二审时间")]
        public DateTime? FirstAuditDate { get; set; }

        [Display(Name = "三审")]
        public int? SecondAudit { get; set; }

        [Display(Name = "未通过原因")]
        public string SecondAuditReason { get; set; }

        [Display(Name = "三审时间")]
        public DateTime? SecondAuditDate { get; set; }

        [Display(Name = "拓展属性  视频审核状态")]
        public string VideoState { get; set; }

        [Display(Name = "拓展属性  视频分类名")]
        public string ClassName { get; set; }

    }
}
