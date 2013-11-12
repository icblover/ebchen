using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ZCJ.Model
{
    /// <summary>
    /// ArticleClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ArticleClass
    {
        public ArticleClass()
        { }
        #region Model
        private int _id;
        private string _classname;
        private int? _parentid = 0;
        private bool _isdelete;
        private string _remark;
        private DateTime? _createdate;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        [Display(Name = "文章分类名称")]
        [Required(ErrorMessage = "*分类名称必填")]
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }

        [Display(Name = "所属分类")]
        [Required(ErrorMessage = "*请选择所属分类")]
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }

        [Display(Name = "启用")]
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }

        [Display(Name = "备注")]
        [StringLength(255)]
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        [Display(Name = "创建日期")]
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        #endregion Model

    }
}

