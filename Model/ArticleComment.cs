using System;
using System.ComponentModel.DataAnnotations;

namespace ZCJ.Model
{
    [Serializable]
    public class ArticleComment
    {
        [Display(Name = "编号")]
        public int id { get; set; }
        [Display(Name = "评论类型")]
        public int CommentType { get; set; }
        [Display(Name = "文章")]
        public int ArticleId { get; set; }
        [Display(Name = "评论者")]
        public string Commenter { get; set; }
        [Display(Name = "评论内容")]
        [Required(ErrorMessage = "*必填")]
        public string CommentText { get; set; }
        [Display(Name = "IP")]
        public string Ip { get; set; }
        [Display(Name = "添加时间")]
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// 拓展属性
        /// </summary>
        [Display(Name = "标题")]
        public string Title { get; set; }
    }
}
