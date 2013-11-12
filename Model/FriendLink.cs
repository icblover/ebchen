using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
	/// <summary>
	/// FriendLink:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class FriendLink 
	{
		public FriendLink()
		{}
		#region Model
		private int _id;
		private string _linkname;
		private string _linkurl;
		private int? _linktype;
		private string _linklogo;
		private int? _haslogo=0;
	    private int? _showorder = 0;
		private DateTime? _createdate;

        [Display(Name = "编号")]
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}


        [Required(ErrorMessage = "*必填")]
        [Display(Name = "链接名称")]
        [StringLength(200,ErrorMessage = "文字数超过200,请删减！")]
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}


        [Display(Name = "链接地址")]
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}


        [Required]
        [Display(Name = "链接类型")]
		public int? LinkType
		{
			set{ _linktype=value;}
			get{return _linktype;}
		}


		[Display(Name = "链接网站logo")]
		public string LinkLogo
		{
			set{ _linklogo=value;}
			get{return _linklogo;}
		}

		[Display(Name = "有图片")]
		public int? HasLogo
		{
			set{ _haslogo=value;}
			get{return _haslogo;}
		}

        
        [Display(Name = "显示顺序")]
        [RegularExpression(@"\d{1,9}")]
	    public int? ShowOrder
	    {
            set { _showorder = value; }
            get { return _showorder; }
	    }


		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}


        /// <summary>
        /// 字段拓展,友情链接类型名称
        /// </summary>
        [Display(Name = "链接类型名")]
        public string LinkTypeName { get; set; }
		#endregion Model

	}
}

