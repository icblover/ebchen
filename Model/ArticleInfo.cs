using System;
using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    /// <summary>
    /// 新闻表，含新闻介绍表，及新闻详细内容表
    /// </summary>
    [Serializable]
    public class ArticleInfo
    {
        [Display(Name = "编号")]
        public int id { get; set; }

        [Required(ErrorMessage = "*必选")]
        [Display(Name = "频道栏目")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "文章标题")]
        public string Title { get; set; }

        [Display(Name = "地区")]
        public int AttributionArea { get; set; }

        [Display(Name = "热点文章")]
        public bool HotFlag { get; set; }

        [Display(Name = "前台显示图片")]
        public bool HasImage { get; set; }

        [Display(Name = "图片地址")]
        public string SmallImgPath { get; set; }

        [Display(Name = "点击次数")]
        public int? ClickInt { get; set; }

        [Display(Name = "创建日期")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "是否删除")]
        public bool IsDeleted { get; set; }

        [Display(Name = "二审")]
        public int? FirstAudit { get; set; }

        [Display(Name = "二审未通过原因")]
        public string FirstAuditReason { get; set; }

        [Display(Name = "二审时间")]
        public DateTime? FirstAuditDate { get; set; }

        [Display(Name = "三审")]
        public int? SecondAudit { get; set; }

        [Display(Name = "三审未通过原因")]
        public string SecondAuditReason { get; set; }

        [Display(Name = "三审时间")]
        public DateTime? SecondAuditDate { get; set; }

        [Display(Name = "文章编号(外键)")]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "文章简介")]
        public string ArticleIntroduce { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "关键字")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "文章内容")]
        public string ArticleContent { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "编辑")]
        public string Author { get; set; }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "来源")]
        public string ArticleFrom { get; set; }

        [Display(Name = "文章审核状态")]
        public string ArticleSatate { get; set; }

        [Display(Name = "频道名称")]
        public string ArticleClassName { get; set; }

    }
}
