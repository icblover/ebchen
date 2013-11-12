using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
	/// <summary>
	/// SiteModule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class SiteModule 
	{
		public SiteModule()
		{}
		#region Model
		private int _id;
		private string _modulename;
		private string _moduleurl;
		private int? _parentid=0;
		private bool? _isclosed;
		private string _remark;
		private DateTime? _createdate;
		
        [Display(Name = "编号")]
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "模块名称")]
		public string ModuleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}

        [Display(Name = "链接地址")]
		public string ModuleUrl
		{
			set{ _moduleurl=value;}
			get{return _moduleurl;}
		}
        
        [Required(ErrorMessage = "*必选")]
        [Display(Name = "所属模块")]
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
        
        [Required]
        [Display(Name = "开启模块")]
        public bool? IsClosed
		{
			set{ _isclosed=value;}
			get{return _isclosed;}
		}

        [Display(Name = "备注")]
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		
        [Display(Name ="创建日期")]
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

