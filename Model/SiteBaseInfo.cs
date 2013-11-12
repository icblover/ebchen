using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
	/// <summary>
	/// SiteBaseInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class SiteBaseInfo 
	{
		public SiteBaseInfo()
		{}
		#region Model
		private int _id;
		private string _sitename;
		private string _sitekeyword;
		private string _telno;
		private string _email;
		private string _zipcode;
		private string _copyright;
		private string _address;
		private string _codestatistics;
		private DateTime? _createdate;
		private DateTime? _updatedate;
		
        [Display(Name = "编号")]
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        [Required(ErrorMessage = "*必填")]
        [Display(Name = "网站名称")]
		public string SiteName
		{
			set{ _sitename=value;}
			get{return _sitename;}
		}
		/// <summary>
		/// meta关键字，seo优化关键字
		/// </summary>
        [Display(Name = "优化关键字")]
		public string SiteKeyWord
		{
			set{ _sitekeyword=value;}
			get{return _sitekeyword;}
		}

        [Display(Name = "联系方式")]
		public string TelNo
		{
			set{ _telno=value;}
			get{return _telno;}
		}

        [Display(Name = "Email")]
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}

        [Display(Name = "邮编")]
		public string ZipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}

		[Display(Name = "版权信息")]
		public string Copyright
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}

		[Display(Name = "公司地址")]
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}

		[Display(Name = "统计代码")]
		public string CodeStatistics
		{
			set{ _codestatistics=value;}
			get{return _codestatistics;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

