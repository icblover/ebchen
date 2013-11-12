using System;
namespace ZCJ.Model
{
    /// <summary>
    /// Article:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ArticleIntro
    {
        public ArticleIntro()
        { }
        #region Model
        private int _id;
        private string _title;
        private int _attributionarea;
        private bool _hotflag=false;
        private bool _hasimage = false;
        private string _smallimgpath;
        private int? _clickint = 0;
        private DateTime? _createdate;
        private bool _isdeleted = false;
        private int? _firstaudit;
        private DateTime? _firstauditdate;
        private string _firstauditreason;
        private int? _secondaudit;
        private DateTime? _secondauditdate;
        private string _secondauditreason;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int ClassId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AttributionArea
        {
            set { _attributionarea = value; }
            get { return _attributionarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool HotFlag
        {
            set { _hotflag = value; }
            get { return _hotflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool HasImage
        {
            set { _hasimage = value; }
            get { return _hasimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallImgPath
        {
            set { _smallimgpath = value; }
            get { return _smallimgpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ClickInt
        {
            set { _clickint = value; }
            get { return _clickint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FirstAudit
        {
            set { _firstaudit = value; }
            get { return _firstaudit; }
        }
        public string FirstAuditReason
        {
            get { return _firstauditreason; }
            set { _firstauditreason = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FirstAuditDate
        {
            set { _firstauditdate = value; }
            get { return _firstauditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SecondAudit
        {
            set { _secondaudit = value; }
            get { return _secondaudit; }
        }
        public string SecondAuditReason
        {
            get { return _secondauditreason; }
            set { _secondauditreason = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SecondAuditDate
        {
            set { _secondauditdate = value; }
            get { return _secondauditdate; }
        }
        #endregion Model
        /// <summary> 拓展属性，频道名称 </summary>
        public string ArticleClassName { get; set; }

    }
}

